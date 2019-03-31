using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Uow
{
    /// <summary>
    /// 单元工作
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取唯一id
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 开始工作单元
        /// </summary>
        void Begin();

        /// <summary>
        /// 回滚工作单元
        /// </summary>
        void Rollback();

        /// <summary>
        /// 提交工作单元
        /// </summary>
        void Commit();

        /// <summary>
        /// 工作单元选项
        /// </summary>
        UnitOfWorkOptions Options { get; }

        /// <summary>
        /// 获取或设置下一节点
        /// </summary>
        IUnitOfWork Next { get; set; }
    }
}
