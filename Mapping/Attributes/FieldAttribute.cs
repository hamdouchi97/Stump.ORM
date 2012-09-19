using System;
using System.Data;

namespace Stump.ORM.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        public FieldAttribute(string name, DbType type)
        {
            Name = name;
            Type = type;
        }

        public FieldAttribute(string name, DbType type, bool primaryKey)
        {
            Name = name;
            Type = type;
            PrimaryKey = primaryKey;
        }

        public string Name
        {
            get;
            set;
        }

        public DbType Type
        {
            get;
            set;
        }

        public bool PrimaryKey
        {
            get;
            set;
        }
    }
}