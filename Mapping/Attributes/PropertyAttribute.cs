using System;

namespace Stump.ORM.Mapping.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : OneColumnAttribute
    {
        public PropertyAttribute()
        {
        }

        public PropertyAttribute(string name)
        {
            Name = name;
        }
    }
}