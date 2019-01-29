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
        /// <summary>
        /// 获取或设置执行会话
        /// </summary>
        ISession Session { get; set; }

        /// <summary>
        /// 获取或设置当前声明
        /// </summary>
        IStatement Statement { get; set; }

        /// <summary>
        /// 获取或设置参数数组
        /// </summary>
        object[] Params { get; set; }
    }
}
