﻿using DbShell.Core.Utility;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace DbShell.Core
{
    /// <summary>
    /// Job, which sets column property
    /// </summary>
    [ContentProperty("Value")]
    public class SetColumnProperty : RunnableBase
    {
        /// <summary>
        /// Name of property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Table, which property should be set
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Regular expression. All matched tables will be processed.
        /// </summary>
        public string Tables { get; set; }

        /// <summary>
        /// Column, which property should be set
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// Regular expressions. All matched columns will be set.
        /// </summary>
        public string Columns { get; set; }

        /// <summary>
        /// Value, which will be set
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// If true, only primary key columns are processed
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// If true, only identity columns are processed
        /// </summary>
        public bool IsIdentity { get; set; }

        private void ProcessTable(TableInfo table)
        {
            if (Column != null)
            {
                var column = table.FindColumn(Column);
                if (column != null)
                {
                    column.Properties[Name] = Value;
                }
            }
            if (Columns != null)
            {
                foreach (var column in table.Columns)
                {
                    if (!Regex.Match(column.Name, Columns).Success) continue;
                    if (IsIdentity && !column.AutoIncrement) continue;
                    if (IsPrimaryKey && !column.PrimaryKey) continue;

                    column.Properties[Name] = Value;
                }
            }
        }

        protected override void DoRun()
        {
            var db = GetDatabaseStructure();
            if (Table != null && Tables != null) throw new Exception("DBSH-00080 SetColumnProperty: both of Table and Tables attribute is set");
            if (Table == null && Tables == null) throw new Exception("DBSH-00081 SetColumnProperty: none of Table and Tables attribute is set");
            if (Column != null && Columns != null) throw new Exception("DBSH-00082 SetColumnProperty: both of Column and Columns attribute is set");
            if (Column == null && Columns == null) throw new Exception("DBSH-00083 SetColumnProperty: none of Column and Columns attribute is set");

            if (Table != null)
            {
                var table = db.FindTable(Table);
                if (table == null) throw new Exception(String.Format("DBSH-00084 Table {0} not found", Table));
                ProcessTable(table);
            }
            if (Tables != null)
            {
                foreach (var table in db.Tables)
                {
                    if (Regex.Match(table.Name, Tables).Success)
                    {
                        ProcessTable(table);
                    }
                }
            }
        }
    }
}