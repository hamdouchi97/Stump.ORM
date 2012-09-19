using System;
using System.Collections.Generic;
using System.Text;
using Stump.ORM.Mapping;
using System.Linq;


namespace Stump.ORM.Sql
{
    public class SqlInsertBuilder : SqlBaseBuilder
    {
        private List<Tuple<string, string>> m_sets = new List<Tuple<string, string>>();
        private string m_table;

        public SqlInsertBuilder()
        {
        }

        public void AddSet(string name, object value)
        {
            AddSet(name, value.ToString(), value is string);
        }

        public void AddSet(string name, string value, bool quote = true)
        {
            m_sets.Add(Tuple.Create(name, quote ? "\"" + value + "\"" : value));
        }

        public void AddSet(Column column)
        {
            AddSet(string.Format("{0}.{1}", QuoteName(column.Table.Name), QuoteName(column.Name)), ":" + column.GetParameterName(), false);
        }

        public void SetInsertTable(string source)
        {
            m_table = source;
        }

        public void SetInsertTable(Table source)
        {
            SetInsertTable(QuoteName(source.Name));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("INSERT INTO ");
            builder.Append(m_table);
            builder.Append("(");
            builder.Append(string.Join(", ", m_sets.Select(entry => entry.Item1)));
            builder.Append(")");

            builder.Append(" VALUES ");

            builder.Append("(");
            builder.Append(string.Join(", ", m_sets.Select(entry => entry.Item2)));
            builder.Append(")");

            builder.Append(";");

            return builder.ToString();
        }
    }
}