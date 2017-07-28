using System;
using System.Collections.Generic;

namespace DapperPlus.Sql
{
    public class DefaultSqlBuilder : ISqlBuilder
    {
        private ISqlAdapter sqlAdapter;

        public DefaultSqlBuilder(ISqlAdapter sqlAdapter)
        {
            this.sqlAdapter = sqlAdapter;
        }

        public string BuildDelete(Type entityType, IEnumerable<string> columns)
        {
            throw new NotImplementedException();
        }

        public string BuildInsert(Type entityType)
        {
            throw new NotImplementedException();
        }

        public string BuildSelect(Type entityType, IEnumerable<string> columns = null)
        {
            throw new NotImplementedException();
        }

        public string BuildUpdate(Type entityType, IEnumerable<string> columns = null)
        {
            throw new NotImplementedException();
        }
    }
}
