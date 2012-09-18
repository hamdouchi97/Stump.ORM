using System.Data;
using Stump.ORM.Sql;

namespace Stump.ORM.Types
{
    public interface IValue
    {
        void BuildLoadQuery(SqlSelectBuilder query);
        void BuildSaveQuery(object query);
        void BuildCreateQuery(object query);
    }
}