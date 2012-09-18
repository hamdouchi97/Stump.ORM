using System;

namespace Stump.ORM.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : OneColumnAttribute
    {
        public PrimaryKey()
        {
            
        }

        public PrimaryKey(string name)
        {
            Name = name;
        }
    }
}