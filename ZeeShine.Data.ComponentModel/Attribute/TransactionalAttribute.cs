using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZeeShine.Data.ComponentModel.Attibute
{
    public class TransactionAttribute : UnitOfWorkAttribute
    {
        public TransactionAttribute() : this(System.Data.IsolationLevel.ReadCommitted, null)
        {
        }

        public TransactionAttribute(IsolationLevel? isolationLevel = System.Data.IsolationLevel.ReadCommitted, TimeSpan? timeout = null) :
            base(isolationLevel, timeout, true)
        {
        }
    }
}
