using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZeeShine.Data.Statement;

namespace ZeeShine.Data
{
    public interface IDapper
    {
        /// <summary>
        /// 获取或设置数据源
        /// </summary>
        IDataSource DataSource
        {
            get;
            set;
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> SelectAsync<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 查询多个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IList<T>> SelectListAsync<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 查询一页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<object> SelectPageAsync<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        Task<int> DeleteAsync(IStatement statement, params object[] parameters);

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        Task<int> UpdateAsync(IStatement statement, params object[] parameters);

        /// <summary>
        /// 插入
        /// </summary>
        /// <returns></returns>
        Task<object> InsertAsync(IStatement statement, params object[] parameters);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Select<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 查询多个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<T> SelectList<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 查询一页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        object SelectPage<T>(IStatement statement, params object[] parameters);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        int Delete(IStatement statement, params object[] parameters);

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        int Update(IStatement statement, params object[] parameters);

        /// <summary>
        /// 插入
        /// </summary>
        /// <returns></returns>
        object Insert(IStatement statement, params object[] parameters);
    }
}
