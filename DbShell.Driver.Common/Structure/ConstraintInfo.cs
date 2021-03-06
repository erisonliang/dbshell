﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class ConstraintInfo : TableObjectInfo
    {
        [XmlAttrib("constraint_name")]
        [DataMember]
        public string ConstraintName { get; set; }

        protected ConstraintInfo(TableInfo ownerTable)
            : base(ownerTable)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ConstraintInfo) source;
            ConstraintName = src.ConstraintName;
        }

        public ConstraintInfo CloneConstraint(TableInfo ownerTable = null)
        {
            return CloneObject(ownerTable) as ConstraintInfo;
        }

        public override FullDatabaseRelatedName GetName()
        {
            return new FullDatabaseRelatedName
            {
                ObjectName = OwnerTable != null ? OwnerTable.FullName : null,
                ObjectType = ObjectType,
                SubName = ConstraintName,
            };
        }

        public override string ToString()
        {
            string res = ConstraintName;
            if (OwnerTable != null && OwnerTable.FullName != null) res = OwnerTable.FullName.ToString() + "." + res;
            return res;
        }
    }
}
