using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ZeeShine.Data.Uow
{
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 获取或设置是否开启事务
        /// </summary>
        public bool IsTransactional { get; set; }

        /// <summary>
        /// 获取或设置事务隔离级别
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 获取或设置超时时间
        /// </summary>
        public TimeSpan? Timeout { get; set; }
    }
}
