using System;
using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfList<T> : List<T>, IDmlfNode
        where T : IDmlfNode
    {
        #region IDmlfNode Members

        public virtual void ForEachChild(Action<IDmlfNode> action)
        {
            action(this);
            foreach (var item in this)
            {
                if (item == null) continue;
                item.ForEachChild(action);
            }
        }

        #endregion

        public virtual void GenSql(ISqlDumper dmp)
        {
            dmp.Put("&>");
            bool was = false;
            foreach (var item in this)
            {
                if (was) dmp.Put(",&n");
                else dmp.Put("&n");
                item.GenSql(dmp);
                was = true;
            }
            dmp.Put("&<");
        }
    }
}