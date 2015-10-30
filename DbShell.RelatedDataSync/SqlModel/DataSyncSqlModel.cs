﻿using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Sql;
using System.IO;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class DataSyncSqlModel
    {
        public List<TargetEntitySqlModel> Entities = new List<TargetEntitySqlModel>();
        public SourceGraphSqlModel SourceGraphModel;
        private bool _allowExternalSources;
        private List<SourceEntitySqlModel> _externalSources = new List<SourceEntitySqlModel>();

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context, bool allowExternalSources)
        {
            _model = model;
            _allowExternalSources = allowExternalSources;
            SourceGraphModel = new SourceGraphSqlModel(model, context, this);
            foreach (var entity in model.Targets)
            {
                Entities.Add(new TargetEntitySqlModel(this, entity, context));
            }
        }

        public SyncModel Dbsh
        {
            get { return _model; }
        }

        private void DumpScript(SqlScriptCompiler cmp, bool useTransaction)
        {
            cmp.PutCommonProlog(useTransaction, _model.SqlPrologBeforeBeginTransaction, _model.SqlPrologAfterBeginTransaction);

            foreach (var source in SourceGraphModel.Entities)
            {
                source.PutMaterialize(cmp);
            }

            foreach (var ent in Entities)
            {
                ent.Run(cmp, useTransaction);
            }

            foreach (var source in SourceGraphModel.Entities)
            {
                source.PutDropMaterialized(cmp);
            }

            cmp.PutCommonEpilog(useTransaction, _model.SqlEpilogBeforeCommitTransaction, _model.SqlEpilogAfterCommitTransaction);
        }

        //private void RunScript(DbConnection conn, IDatabaseFactory factory, Action<SqlScriptCompiler> prolog, Action<SqlScriptCompiler> epilog, IShellContext context, string procname, bool useTransaction)
        //{
        //    var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());

        //    var sw = new StringWriter();
        //    var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
        //    so.OverrideCommandDelimiter(";");
        //    var dmp = factory.CreateDumper(so, new SqlFormatProperties());
        //    var cmp = new SqlScriptCompiler(dmp, this, context, procname);

        //    if (prolog != null) prolog(cmp);

        //    DumpScript(cmp, useTransaction);

        //    if (epilog != null) epilog(cmp);

        //    using (var cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = sw.ToString();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public void AddExternalSource(SourceEntitySqlModel sourceEntity)
        {
            if (!_allowExternalSources) throw new Exception("DBSH-00214 External sources not supported in this context");
            _externalSources.Add(sourceEntity);
        }

        private void FillExternalSources(DbConnection conn, IDatabaseFactory factory, IShellContext context)
        {
            if (!_externalSources.Any()) return;

            var sw = new StringWriter();
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());

            foreach (var exSource in _externalSources)
            {
                var tbl = new TableInfo(null) { FullName = exSource.ExternalDataName };
                foreach(var col in exSource.Dbsh.Columns)
                {
                    tbl.Columns.Add(new ColumnInfo(tbl)
                    {
                        Name = col.Name,
                        DataType = col.DataType ?? "nvarchar(500)",
                    });
                }
                dmp.CreateTable(tbl);

                var copyTable = new DbShell.Core.CopyTable
                {
                    Source = exSource.Dbsh.DataSource,
                    Target = new DbShell.Core.Table
                    {
                        Name = exSource.ExternalDataName.Name,
                        StructureOverride = tbl,
                    },
                };
                var runnable = (IRunnable)copyTable;
                runnable.Run(context);
            }
        }

        private void FreeExternalSources(DbConnection conn, IDatabaseFactory factory, IShellContext context)
        {
            if (!_externalSources.Any()) return;

            var sw = new StringWriter();
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());

            foreach (var exSource in _externalSources)
            {
                var tbl = new TableInfo(null) { FullName = exSource.ExternalDataName };
                dmp.DropTable(tbl, false);
            }
        }

        public void Run(DbConnection conn, IDatabaseFactory factory, IShellContext context, bool useTransaction)
        {
            FillExternalSources(conn, factory, context);
            var cmp = new SqlScriptCompiler(factory, this, context, null);
            cmp.PutScriptProlog(useTransaction);
            DumpScript(cmp, useTransaction);
            ExecuteScript(conn, cmp.GetCompiledSql());
            FreeExternalSources(conn, factory, context);
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, bool overwriteExisting)
        {
            string sql = GenerateCreateProcedure(factory, name, context, useTransaction, overwriteExisting);
            ExecuteScript(conn, sql);
        }

        private void ExecuteScript(DbConnection conn, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private string GenerateCreateProcedureCore(IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, string createKeyword)
        {
            var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());
            cmp.PutProcedureHeader(name, useTransaction, createKeyword);
            DumpScript(cmp, useTransaction);
            cmp.PutProcedureFooter();
            return cmp.GetCompiledSql();
        }

        public string GenerateCreateProcedure(IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, bool overwriteExisting)
        {
            if (overwriteExisting)
            {
                string sqlCore = GenerateCreateProcedureCore(factory, name, context, useTransaction, "");
                var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());
                cmp.CreateOrAlterProcedure(name, sqlCore);
                return cmp.GetCompiledSql();
            }
            else
            {
                return GenerateCreateProcedureCore(factory, name, context, useTransaction, "create");
            }
        }

        public string GenerateScript(IDatabaseFactory factory, IShellContext context, bool useTransaction)
        {
            var cmp = new SqlScriptCompiler(factory, this, context, null);

            cmp.PutScriptProlog(useTransaction);
            DumpScript(cmp, useTransaction);

            return cmp.GetCompiledSql();
        }
    }
}
