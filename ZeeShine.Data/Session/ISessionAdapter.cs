using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Session
{
    public interface ISessionAdapter
    {
        /// <summary>
        /// 获取是否支持事务
        /// </summary>
        bool SupportTransaction { get; }

        /// <summary>
        /// 包装分页语句
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="rawExpression"></param>
        /// <param name="pageExpression"></param>
        /// <param name="countExpression"></param>
        /// <returns></returns>
        bool WrapPagination(long skip, long take, string rawExpression, out string pageExpression, out string countExpression);

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        string ParameterPrefix { get; }
    }
}
