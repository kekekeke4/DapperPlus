using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Session
{
    /// <summary>
    /// 会话接口
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// 获取会话适配器
        /// </summary>
        ISessionAdapter Adapter { get; }

        /// <summary>
        /// 获取会话所属的数据源
        /// </summary>
        IDataSource DataSource { get; }
    }
}
