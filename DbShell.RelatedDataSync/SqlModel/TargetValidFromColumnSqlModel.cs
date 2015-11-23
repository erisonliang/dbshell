﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetValidFromColumnSqlModel : TargetColumnSqlModelBase
    {
        private string _name;
        public TargetValidFromColumnSqlModel(string name, ColumnInfo colinfo)
            : base(colinfo)
        {
            _name = name;
        }

        public override bool IsKey => false;
        public override string Name => _name;
        public override bool Compare => false;
        public override bool Update => false;

        public override DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate)
        {
            return SqlScriptCompiler.ImportDateTimeExpression;
        }
    }
}