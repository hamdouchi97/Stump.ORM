using System.Data;
using System.Reflection;
using Stump.ORM.Mapping.Attributes;
using Stump.ORM.Sql;
using Stump.ORM.Types;

namespace Stump.ORM.Mapping
{
    public class Column
    {
        public Column(Table table, PropertyInfo property)
        {
            Table = table;
            Property = property;
            MemberInfo = property;
        }

        public Column(Table table, FieldInfo field)
        {
            Table = table;
            Field = field;
            MemberInfo = field;
        }

        public Table Table
        {
            get;
            set;
        }

        public IValue Value
        {
            get;
            set;
        }

        public FieldAttribute Attribute
        {
            get;
            set;
        }

        public KeyAttribute KeyAttribute
        {
            get;
            set;
        }

        public FieldInfo Field
        {
            get;
            set;
        }

        public PropertyInfo Property
        {
            get;
            set;
        }

        public MemberInfo MemberInfo
        {
            get;
            set;
        }

        public object GetValue()
        {
            return null;
        }

        public void SetValue()
        {

        }

        // here properties get with the attribute
        public string Name
        {
            get { return Attribute.Name; }
        }

        public bool NotNull
        {
            get;
            set;
        }

        public DbType DbType
        {
            get;
            set;
        }

        public bool IsPrimaryKey
        {
            get;
            set;
        }

        public object DefaultValue
        {
            get;
            set;
        }

        public string GetParameterName()
        {
            return string.Format("{0}_{1}", Table.Name, Name);
        }
    }
}