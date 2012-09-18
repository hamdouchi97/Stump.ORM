using System;

namespace Stump.ORM.Sql
{
    public class ComparaisonClause : IWhereClause
    {
        public ComparaisonClause()
        {
        }

        public ComparaisonClause(string left, Operator op, string right)
        {
            SetLeft(left);
            Operator = op;
            SetRight(right);
        }

        public ComparaisonClause(string left, Operator op, object right)
        {
            SetLeft(left);
            Operator = op;
            SetRight(right);
        }

        public string Left
        {
            get;
            set;
        }

        public Operator Operator
        {
            get;
            set;
        }

        public string Right
        {
            get;
            set;
        }

        public void SetLeft(string str)
        {
            Left = str;
        }

        public void SetRight(string str, bool quote = true)
        {
            if (quote && !(str.StartsWith("'") && str.EndsWith("'")) &&
                !(str.StartsWith("\"") && str.EndsWith("\"")))
                str = "'" + str + "'";

            Right = str;
        }

        public void SetRight(object obj)
        {
            if (obj is string)
                SetRight(obj as string);
            else
            {
                Right = obj.ToString();
            }
        }

        public static string GetOperatorString(Operator op)
        {
            switch (op)
            {
                case Operator.EQ:
                    return "=";
                case Operator.NOTEQ:
                    return "<>";
                case Operator.LESS:
                    return "<";
                case Operator.LESS_EQ:
                    return "<=";
                case Operator.GREATER:
                    return ">";
                case Operator.GREATER_EQ:
                    return ">=";
                case Operator.IN:
                    return "IN";
                case Operator.BETWEEN:
                    return "BETWEEN";
                case Operator.LIKE:
                    return "LIKE";
                default:
                    throw new Exception(string.Format("Operator {0} is invalid", op));
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Left, GetOperatorString(Operator), Right);
        }
    }
}