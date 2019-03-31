using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Executor
{
    /// <summary>
    /// 执行器
    /// </summary>
    public interface IExecutor
    {
        object Execute(IExecuteContext context);
    }
}
