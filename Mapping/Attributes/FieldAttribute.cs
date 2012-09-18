using System;

namespace Stump.ORM.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldAttribute : OneColumnAttribute
    {
        public FieldAttribute()
        {
            
        }

        public FieldAttribute(string name)
        {
            Name = name;
        }
    }
}