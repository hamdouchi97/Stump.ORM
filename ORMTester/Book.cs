using System;
using Stump.ORM.Mapping.Attributes;

namespace ORMTester
{
    [Table("books")]
    public class Book
    {
        [PrimaryKey]
        public int Id
        {
            get;
            set;
        }

        [Property]
        public string Name
        {
            get;
            set;
        }

        [Property]
        public string Author
        {
            get;
            set;
        }

        [Property]
        public DateTime PublicationDate
        {
            get;
            set;
        }
    }
}