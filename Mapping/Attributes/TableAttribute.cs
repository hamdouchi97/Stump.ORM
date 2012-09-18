using System;

namespace Stump.ORM.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute()
        {
            
        }

        public TableAttribute(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
}