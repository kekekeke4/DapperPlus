using System;
using System.Collections.Generic;
using System.Text;
using ZeeShine.Data.Session;
using ZeeShine.Data.Statement;

namespace ZeeShine.Data.Executor
{
    /// <summary>
    /// 执行上下文
    /// </summary>
    public interface IExecuteContext
    {
        ISession Session { get; set; }

        IStatement Statement { get; set; }
    }
}
