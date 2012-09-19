namespace Stump.ORM.Sql
{
    public abstract class SqlBaseBuilder
    {
        public const char QuoteChar = '`';
        public const char StringQuoteChar = '\"';

        protected string QuoteName(string str)
        {
            if (IsQuoted(str, QuoteChar))
                return str;

            return QuoteChar + str + QuoteChar;
        }

        protected string UnQuoteName(string str)
        {
            if (IsQuoted(str, QuoteChar))
                return str.Substring(1, str.Length - 2);

            return str;
        }

        protected bool IsQuoted(string str, char quoteChar)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return str[0] == quoteChar && str.Length > 1 && str[str.Length - 1] == quoteChar;
        }

        protected string QuoteIfString(object obj)
        {
            if (obj is string)
                return QuoteIfString(obj.ToString());

            return obj.ToString();
        }

        protected string QuoteIfString(string str)
        {
            if (IsQuoted(str, StringQuoteChar))
                return str;

            return StringQuoteChar + str + StringQuoteChar;
        }
    }
}