using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.ORM.Sql;

namespace ORMTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new SqlSelectBuilder();
            builder.AddSourceTable("accounts");
            builder.AddSelectResult("*");
            builder.AddWhereClause(new ComparaisonClause("Id", Operator.EQ, 10));
            builder.AddWhereClause(new BoolLogicClause(BoolLogicClauseType.AND));
            builder.AddWhereClause(new ComparaisonClause("AdminRights", Operator.GREATER, 3));

            Console.WriteLine(builder.ToString());

            Console.Read();
        }
    }
}
