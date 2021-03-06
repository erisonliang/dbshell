﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfRelationCollection : DmlfList<DmlfRelation>
    {
        public void LoadCollection(XmlNodeList list)
        {
            foreach (XmlElement elem in list)
            {
                Add(new DmlfRelation(elem));
            }
        }

        public void SaveCollection(XmlElement xml, string elemName)
        {
            foreach (var item in this)
            {
                item.SaveToXml(xml.AddChild(elemName));
            }
        }

        public NameWithSchema FindTableName(DmlfColumnRef col)
        {
            if (col.Source == null) return null;
            if (col.Source.TableOrView != null) return col.Source.TableOrView;
            return FindTableAlias(col.Source.Alias);
        }

        public NameWithSchema FindTableAlias(string alias)
        {
            foreach (var rel in this)
            {
                if (rel.Reference.Alias == alias) return rel.Reference.TableOrView;
            }
            return null;
        }

        public override void GenSql(ISqlDumper dmp)
        {
            foreach (var rel in this)
            {
                rel.GenSql(dmp);
            }
        }

        public DmlfSource FindSourceWithAlias(string alias)
        {
            foreach (var rel in this)
            {
                if (rel.Reference != null && rel.Reference.Alias == alias) return rel.Reference;
            }
            return null;
        }
    }

    public class DmlfSource : DmlfBase
    {
        public static readonly DmlfSource BaseTable = new DmlfSource {Alias = "basetbl"};

        private string m_alias;

        [XmlElem]
        public bool WithNoLock { get; set; }

        [XmlElem]
        public NameWithSchema TableOrView { get; set; }

        [XmlSubElem]
        public LinkedDatabaseInfo LinkedInfo { get; set; }

        [XmlElem]
        public string Alias
        {
            get { return m_alias; }
            set
            {
                m_alias = value;
                if (m_alias.IsEmpty()) m_alias = null;
            }
        }

        [XmlSubElem]
        public DmlfSelect SubQuery { get; set; }

        [XmlElem]
        public string SubQueryString { get; set; }

        public void GenSqlDef(ISqlDumper dmp)
        {
            int sources = 0;
            if (TableOrView != null) sources++;
            if (SubQuery != null) sources++;
            if (SubQueryString != null) sources++;
            if (sources != 1) throw new Exception("DBSH-00095 DmlfSource should have exactly one source");

            if (TableOrView != null)
            {
                dmp.Put("%l%f", LinkedInfo, TableOrView);
            }
            if (SubQuery != null)
            {
                dmp.Put("(");
                SubQuery.GenSql(dmp);
                dmp.Put(")");
            }
            if (SubQueryString != null)
            {
                dmp.Put("(");
                dmp.WriteRaw(SubQueryString);
                dmp.Put(")");
            }
            if (Alias != null)
            {
                dmp.Put(" %i", Alias);
            }
            if (WithNoLock)
            {
                dmp.Put(" ^with (^nolock)");
            }
        }

        public bool GenSqlRef(ISqlDumper dmp)
        {
            if (Alias != null)
            {
                dmp.Put("%i", Alias);
                return true;
            }
            else if (TableOrView != null)
            {
                dmp.Put("%f", TableOrView);
                return true;
            }
            //else if (handler != null && handler.BaseTable != null && handler.BaseTable != this)
            //{
            //    return handler.BaseTable.GenSqlRef(dmp, handler);
            //}
            return false;
        }

        public string AliasOrName
        {
            get
            {
                if (Alias != null) return Alias;
                return TableOrView.SafeToString();
            }
        }

        public bool IsSimpleSource
        {
            get { return SubQuery == null && SubQueryString == null; }
        }

        public override string ToString()
        {
            //if (m_alias == "basetbl") return "(SOURCE)";
            return AliasOrName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int res = 0;
                if (m_alias != null) res += m_alias.GetHashCode();
                if (TableOrView != null) res += TableOrView.GetHashCode();
                return res;
            }
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfSource) obj;
            return m_alias == o.m_alias && TableOrView == o.TableOrView;
        }

        public static string GetAliasBase(string name)
        {
            var sb = new StringBuilder();
            bool wasbig = false;
            bool isfirst = true;
            foreach (var ch in name)
            {
                if (!wasbig && (Char.IsUpper(ch) || isfirst)) sb.Append(Char.ToLower(ch));
                wasbig = Char.IsUpper(ch);
                isfirst = false;
            }
            return sb.ToString();
        }

        public static string AllocateAlias(HashSet<string> usedAliases, string aliasBase)
        {
            int i = 1;
            while (usedAliases.Contains(aliasBase + i)) i++;
            usedAliases.Add(aliasBase + i);
            return aliasBase + i;
        }

        public DmlfSource GetSimpleSourceCopy()
        {
            if (IsSimpleSource)
            {
                return new DmlfSource
                    {
                        Alias = Alias,
                        LinkedInfo = LinkedInfo,
                        TableOrView = TableOrView,
                    };
            }
            return null;
        }
    }

    public class DmlfRelation : DmlfBase
    {
        [XmlSubElem]
        public DmlfSource Reference { get; set; }
        [XmlElem]
        public DmlfJoinType JoinType { get; set; }
        [XmlCollection(typeof(DmlfConditionBase), "Condition")]
        public DmlfList<DmlfConditionBase> Conditions { get; set; }

        public DmlfRelation()
        {
            Conditions = new DmlfList<DmlfConditionBase>();
        }

        public DmlfRelation(XmlElement xml)
        {
            Conditions = new DmlfList<DmlfConditionBase>();
            this.LoadProperties(xml);
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SaveProperties(xml);
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Reference != null) Reference.ForEachChild(action);
            if (Conditions != null) Conditions.ForEachChild(action);
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("&n");
            JoinType.GenSql(dmp);
            dmp.Put(" ");
            Reference.GenSqlDef(dmp);
            if (Conditions.Any())
            {
                dmp.Put(" ^on ");
                bool was = false;
                foreach (var cond in Conditions)
                {
                    if (was) dmp.Put(" ^and ");
                    cond.GenSql(dmp);
                    was = true;
                }
            }
        }

        public DmlfRelation Clone()
        {
            var doc = XmlTool.CreateDocument("Relation");
            SaveToXml(doc.DocumentElement);
            return new DmlfRelation(doc.DocumentElement);
        }

        public override string ToString()
        {
            if (Reference != null) return Reference.ToString();
            return "(null)";
        }
    }

    public class DmlfColumnRef : DmlfBase
    {
        [XmlSubElem]
        public DmlfSource Source { get; set; }
        [XmlElem]
        public string ColumnName { get; set; }

        public override void GenSql(ISqlDumper dmp)
        {
            if (Source != null)
            {
                if (Source.GenSqlRef(dmp))
                {
                    dmp.Put(".");
                }
            }
            //else if (handler != null)
            //{
            //    var b = handler.BaseTable;
            //    if (b != null)
            //    {
            //        b.GenSqlRef(dmp, handler);
            //        dmp.Put(".");
            //    }
            //}
            dmp.Put("%i", ColumnName);
        }

        public override string ToString()
        {
            if (Source != null && Source != DmlfSource.BaseTable) return Source.ToString() + "." + ColumnName;
            return ColumnName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int res = 0;
                if (ColumnName != null) res += ColumnName.GetHashCode();
                if (Source != null) res += Source.GetHashCode();
                return res;
            }
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfColumnRef)obj;
            return ColumnName == o.ColumnName && Source == o.Source;
        }

        public static DmlfColumnRef GetBaseColumn(string colname)
        {
            return new DmlfColumnRef
            {
                ColumnName = colname,
                Source = DmlfSource.BaseTable
            };
        }

        public static DmlfColumnRef[] BuildFromArray(string[] cols, DmlfSource source)
        {
            return (
                from c in cols select new DmlfColumnRef { ColumnName = c, Source = source }
                ).ToArray();
        }

        public ColumnInfo FindSourceColumn(DatabaseInfo db)
        {
            if (Source == null || Source.TableOrView == null) return null;
            var table = db.FindTable(Source.TableOrView);
            if (table == null) return null;
            return table.FindColumn(ColumnName);
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Source != null) Source.ForEachChild(action);
        }
    }
}
