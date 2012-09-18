namespace Stump.ORM.Mapping
{
    public class Column
    {
        public Table Table
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsNullable
        {
            get;
            set;
        }
    }
}