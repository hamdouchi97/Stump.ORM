using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.ORM.Mapping;

namespace Stump.ORM.Sql
{
    public class SqlCreateTableBuilder : SqlBaseBuilder
    {
        private string m_table;
        private List<Column> m_columns = new List<Column>();

        public SqlCreateTableBuilder()
        {
            
        }

        public void SetTable(string table)
        {
            m_table = table;
        }

        public void SetTable(Table table)
        {
            SetTable(QuoteName(table.Name));
        }

        public void AddColumn(Column column)
        {
            m_columns.Add(column);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("CREATE TABLE ");
            builder.Append(m_table);
            builder.Append("(");

            for (int i = 0; i < m_columns.Count; i++)
            {
                var column = m_columns[i];

                builder.Append(QuoteName(column.Name));
                builder.Append(" ");
                builder.Append(column.DbType); // transform it
                builder.Append(" ");
                builder.Append(column.NotNull ? "NOT NULL" : "NULL");

                if (column.DefaultValue != null)
                {
                    builder.Append(" DEFAULT ");
                    builder.Append(QuoteIfString(column.DefaultValue));
                }

                if (column.IsPrimaryKey)
                {
                    builder.Append(" PRIMARY KEY");
                }

                if (i < m_columns.Count - 1)
                    builder.Append(", ");
            }

            builder.Append(";");

            return builder.ToString();
        }
    }
}