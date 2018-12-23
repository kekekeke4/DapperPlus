using System;
using System.Collections.Generic;
using System.Text;

namespace ZeeShine.Data.Statement
{
    public interface IStatement
    {
        /// <summary>
        /// 获取或设置唯一Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 获取或设置Dapper的命名空间
        /// </summary>
        string Namespace { get; set; }

        ///// <summary>
        ///// 获取或设置参数映射
        ///// </summary>
        //ParameterMapping ParameterMap { get; set; }

        ///// <summary>
        ///// 获取表达式Token集合
        ///// </summary>
        //IList<ExpressionToken> Tokens { get; }

        ///// <summary>
        ///// 获取表达式(eg:sql)
        ///// </summary>
        //IExpressionTree ExpressionTree { get; set; }
    }
}
