using System;
using System.Collections.Generic;
using System.Text;
using Stump.ORM.Mapping;

namespace Stump.ORM.Sql
{
    public class SqlUpdateBuilder : SqlBaseBuilder
    {
        private List<Tuple<string, string>> m_sets = new List<Tuple<string, string>>();
        private List<string> m_sources = new List<string>();
        private WhereStatement m_whereStatement;

        public SqlUpdateBuilder()
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

        public void AddUpdateTable(string source)
        {
            if (m_sources.Contains(source))
                return;

            m_sources.Add(source);
        }

        public void AddUpdateTable(Table source)
        {
            AddUpdateTable(QuoteName(source.Name));
        }

        public void AddWhereClause(IWhereClause clause)
        {
            if (m_whereStatement == null)
                m_whereStatement = new WhereStatement();

            m_whereStatement.AddClause(clause);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("UPDATE ");
            builder.Append(string.Join(", ", m_sources));
            builder.Append(" SET ");


            for (int i = 0; i < m_sets.Count; i++)
            {
                var result = m_sets[i];

                builder.Append(result.Item1);
                builder.Append(" = ");
                builder.Append(result.Item2);

                if (i != m_sets.Count - 1)
                    builder.Append(", ");
            }

            if (m_whereStatement != null)
            {
                builder.Append(" WHERE ");
                builder.Append(m_whereStatement.ToString());
            }

            builder.Append(";");

            return builder.ToString();
        }
    }
}