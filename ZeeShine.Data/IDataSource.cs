using System;
using System.Collections.Generic;
using System.Text;
using ZeeShine.Data.Session;

namespace ZeeShine.Data
{
    public interface IDataSource
    {
        /// <summary>
        /// 获取或设置数据源名称
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 获取会话
        /// </summary>
        /// <returns></returns>
        ISession GetSession();
    }
}
