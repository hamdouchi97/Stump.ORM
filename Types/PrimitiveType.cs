using System;
using System.Data;
using Stump.ORM.Mapping;
using Stump.ORM.Sql;

namespace Stump.ORM.Types
{
    public abstract class PrimitiveType : IValue
    {
        public Column Column
        {
            get;
            set;
        }

        public abstract DbType DbType
        {
            get;
        }

        public abstract Type Type
        {
            get;
        }

        public virtual void BuildLoadQuery(SqlSelectBuilder sqlSelectBuilder)
        {
            sqlSelectBuilder.AddSourceTable(Column.Table);
            sqlSelectBuilder.AddSelectResult(Column.Name);
        }

        public abstract object Get(IDataReader reader);
        public abstract void Set(IDataParameter reader);

        public abstract void BuildSaveQuery(object query);
        public abstract void BuildCreateQuery(object query);
    }
}