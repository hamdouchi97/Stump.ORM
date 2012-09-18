using System.Collections.Generic;
using System.Text;
using Stump.ORM.Mapping;

namespace Stump.ORM.Sql
{
    public class SqlSelectBuilder : SqlBaseBuilder
    {
        private List<string> m_results = new List<string>();
        private List<string> m_sources = new List<string>();
        private WhereStatement m_whereStatement;

        public SqlSelectBuilder()
        {
        }

        public void AddSelectResult(string name)
        {
            m_results.Add(name);
        }

        public void AddSourceTable(string source)
        {
            if (m_sources.Contains(source))
                return;

            m_sources.Add(source);
        }

        public void AddSourceTable(Table source)
        {
            AddSourceTable(source.Name);
        }

        public void AddWhereClause(IWhereClause clause)
        {
            if (m_whereStatement == null)
                m_whereStatement = new WhereStatement();

            m_whereStatement.AddClause(clause);
        }

        public override string ToString()
        {
            return ToSqlString().ActualString;
        }

        public override SqlString ToSqlString()
        {
            var builder = new StringBuilder();

            builder.Append("SELECT ");
            builder.Append(string.Join(", ", m_results));
            builder.Append(" FROM ");
            builder.Append(string.Join(", ", m_sources));

            if (m_whereStatement != null)
            {
                builder.Append(" WHERE ");
                builder.Append(m_whereStatement.ToString());
            }

            builder.Append(";");

            return new SqlString(builder.ToString());
        }
    }
}