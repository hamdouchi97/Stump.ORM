using System;

namespace Stump.ORM.Sql
{
    public enum BoolLogicClauseType
    {
        AND,
        OR
    }

    public class BoolLogicClause : IWhereClause
    {
        public BoolLogicClause()
        {
            
        }

        public BoolLogicClause(BoolLogicClauseType type)
        {
            Type = type;
        }

        public BoolLogicClauseType Type
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (Type != BoolLogicClauseType.OR &&
                Type != BoolLogicClauseType.AND)
                throw new Exception(string.Format("Invalid BoolLogicClauseType {0}", Type));

            return Type == BoolLogicClauseType.AND ? "AND" : "OR";
        }
    }
}