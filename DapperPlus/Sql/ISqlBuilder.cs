using System;
using System.Collections.Generic;

namespace DapperPlus.Sql
{
    public interface ISqlBuilder
    {
        /// <summary>
        /// 构建查询语句
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="entityType">Entity type.</param>
        string BuildInsert(Type entityType);

        /// <summary>
        /// 构建更新语句
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="entityType">Entity type.</param>
        /// <param name="columns">要更新的列,为null表示全更新</param>
        string BuildUpdate(Type entityType, IEnumerable<string> columns = null);

        /// <summary>
        /// 构建删除语句
        /// </summary>
        /// <returns>The delete by columns.</returns>
        /// <param name="entityType">Entity type.</param>
        /// <param name="columns">删除的列条件</param>
        string BuildDelete(Type entityType, IEnumerable<string> columns);

		/// <summary>
		/// 构建选择语句
		/// </summary>
		/// <returns>The select.</returns>
		/// <param name="entityType">Entity type.</param>
		/// <param name="columns">表示要选择的列,为空表示全选择</param>
		string BuildSelect(Type entityType,IEnumerable<string> columns=null);

    }
}
