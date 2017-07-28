using System;
using System.Data;

namespace DapperPlus.Sql
{
    public interface ISqlAdapter
    {
        IDbConnection CreateConnection(string connString = null);

        bool IsSupportGuid { get; }

        string EscapeTableName(string tableName);

        string EscapeSqlIdentifier(string sqlIdentifier);

        string GetParameterPrefix();

        string BuildPaging(SqlSegments sqlSegments, object sqlArgs, long skip, long take);
    }
}
