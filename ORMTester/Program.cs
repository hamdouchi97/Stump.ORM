using System;
using MySql.Data.MySqlClient;
using Stump.ORM;
using SubSonic.DataProviders;
using SubSonic.Extensions;

namespace ORMTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new MySqlConnection("database=test;uid=root;password=;");
            db.Open();
            var provider = ProviderFactory.GetProvider(db.ConnectionString, "MySql.Data.MySqlClient");
            var query = typeof(Book).ToSchemaTable(provider).CreateSql;
            db.Execute(query);
            db.Insert<Book>(new Book()
            {
                Author = "me",
                Name = "mine",
                PublicationDate = DateTime.Now
            });

            var book = db.Get<Book>(1);

            Console.Read();
        }
    }
}
