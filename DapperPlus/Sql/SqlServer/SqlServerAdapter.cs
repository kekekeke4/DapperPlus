using System;
using System.Data;

namespace DapperPlus.Sql.SqlServer
{
    public class SqlServerAdapter:ISqlAdapter
    {
        public SqlServerAdapter()
        {
        }

        public bool IsSupportGuid => false;

        public string BuildPaging(SqlSegments sqlSegments, object sqlArgs, long skip, long take)
        {
            throw new NotImplementedException();
        }

        public IDbConnection CreateConnection(string connString = null)
        {
            throw new NotImplementedException();
        }

        public string EscapeSqlIdentifier(string sqlIdentifier)
        {
            throw new NotImplementedException();
        }

        public string EscapeTableName(string tableName)
        {
            throw new NotImplementedException();
        }

        public string GetParameterPrefix()
        {
            throw new NotImplementedException();
        }
    }
}
