using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ZeeShine.Data.Session;

namespace ZeeShine.Data.DapperPlus.Session
{
    public class Session : ISession
    {
        public ISessionAdapter Adapter => throw new NotImplementedException();

        public IDataSource DataSource => throw new NotImplementedException();

        internal IDbConnection DbConnection { get; set; }
    }
}
