﻿using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;

namespace DbShell.RelatedDataSync
{
    [ContentProperty(nameof(Columns))]
    public class Target
    {
        [XamlProperty]
        public string TableSchema { get; set; }

        [XamlProperty]
        public string TableName { get; set; }

        [XamlProperty]
        public string PrimarySource { get; set; }

        [XamlProperty]
        public string Alias { get; set; }

        [XamlProperty]
        public List<TargetColumn> Columns { get; private set; } = new List<TargetColumn>();

        [XamlProperty]
        public LifetimeHandlerBase LifetimeHandler { get; set; } = new LifetimeHandlerBase();

        public void ReplaceTargetSchemaByTemplate(string template)
        {
            TableSchema = template;
        }
    }
}