using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Uow
{
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// 获取当前工作单元
        /// </summary>
        IUnitOfWork Current { get; }
    }
}
