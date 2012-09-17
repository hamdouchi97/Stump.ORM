using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Stump.ORM.Sql
{
    public class WhereStatement
    {
        private List<IWhereClause> m_clauses = new List<IWhereClause>();

        public WhereStatement()
        {
            
        }

        public void AddClause(IWhereClause clause)
        {
            m_clauses.Add(clause);
        }

        public override string ToString()
        {
            return string.Join(" ", m_clauses.Select(entry => entry.ToString()));
        }
    }
}