using System;
using System.Data;
using Stump.ORM.Sql;

namespace Stump.ORM.Types.Primitives
{
    public class Int32Type : PrimitiveType
    {
        public override DbType DbType
        {
            get
            {
                return DbType.Int32;
            }
        }

        public override Type Type
        {
            get
            {
                return typeof(int);
            }
        }

        public override object Get(IDataReader reader)
        {
            return reader.GetInt32(reader.GetOrdinal(Column.Name));
        }

        public override void Set(IDataParameter parameter)
        {
        }
    }
}