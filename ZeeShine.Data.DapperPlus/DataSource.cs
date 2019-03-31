using System;
using System.Collections.Generic;
using System.Text;
using ZeeShine.Data.Session;

namespace ZeeShine.Data.DapperPlus
{
    public class DataSource : IDataSource
    {
        public string Name
        {
            get;
            set;
        }

        public ISession Fork()
        {
            throw new NotImplementedException();
        }

        public void Recycle(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
