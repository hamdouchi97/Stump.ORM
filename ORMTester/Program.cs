using System;
using System.Collections.Generic;
using System.Reflection;
using MySql.Data.MySqlClient;
using Stump.ORM;
using Stump.ORM.SubSonic.DataProviders;
using Stump.ORM.SubSonic.Extensions;
using Database = Stump.ORM.Database;

namespace ORMTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DatabaseAccessor(new DatabaseConfiguration()
            {
                DbName = "test",
                Host = "localhost",
                Password = "",
                User = "root",
                ProviderName = "MySql.Data.MySqlClient",
            });

            db.RegisterMappingAssembly(Assembly.GetExecutingAssembly());
            
            db.Initialize();
            db.OpenConnection();

            db.Database.Execute("DELETE FROM authors");
            db.Database.Execute("DELETE FROM books");

            var author = new Author()
            {
                Books = new List<Book>(),
                Name = "Bernard"
            };

            var author2 = new Author()
            {
                Books = new List<Book>(),
                Name = "Clement"
            };

            var book = new Book()
            {
                Author = author,
                Name = "Livre de Bernard 1",
                PublicationDate = DateTime.Now,
            };

            var book2 = new Book()
            {
                Author = author,
                Name = "Livre de Bernard 2",
                PublicationDate = DateTime.Now,
            };

            var book3 = new Book()
            {
                Author = author2,
                Name = "Livre de Clement 1",
                PublicationDate = DateTime.Now,
            };

            author.Books.Add(book);
            author.Books.Add(book2);
            author2.Books.Add(book3);

            db.Database.Insert(author);
            db.Database.Insert(author2);
            db.Database.Insert(book);
            db.Database.Insert(book2);
            db.Database.Insert(book3);

            var books = db.Database.Fetch<Book, Author, Book>(new BookRelator().Map, BookRelator.FetchQuery);
            var authors = db.Database.Fetch<Author, Book, Author>(new AuthorRelator().Map, AuthorRelator.FetchQuery);

            Console.Read();
        }
    }
}
