using System;
using System.Data;
using Stump.ORM;

namespace ORMTester
{
    public class Book
    {
        public Book()
        {
            
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public DateTime PublicationDate
        {
            get;
            set;
        }
    }
}