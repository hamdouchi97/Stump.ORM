using System;
using System.Data;
using Stump.ORM.Mapping.Attributes;

namespace ORMTester
{
    [Table("books")]
    public class Book
    {
        [Field("Id", DbType.Int32, true)]
        public int Id
        {
            get;
            set;
        }

        [Field("Name", DbType.AnsiString)]
        public string Name
        {
            get;
            set;
        }

        [Field("Author", DbType.AnsiString)]
        public string Author
        {
            get;
            set;
        }

        [Field("PublicationDate", DbType.DateTime)]
        public DateTime PublicationDate
        {
            get;
            set;
        }
    }
}