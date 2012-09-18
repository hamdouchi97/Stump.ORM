using System;

namespace Stump.ORM.Mapping.Attributes
{
    public abstract class OneColumnAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}