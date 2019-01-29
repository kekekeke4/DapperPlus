using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZeeShine.Data.ComponentModel;
using ZeeShine.Data.Session;
using ZeeShine.Data.Statement;
using ZeeShine.Data.Uow;

namespace ZeeShine.Data.DapperPlus
{
    public class Dapper : IDapper
    {
        public IDataSource DataSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IUnitOfWorkManager UnitOfWorkManager { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Delete(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public object Insert(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<object> InsertAsync(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public T Select<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> SelectList<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> SelectListAsync<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Pagination<T> SelectPage<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<T>> SelectPageAsync<T>(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int Update(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IStatement statement, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        protected virtual ISession ForkSession()
        {
            return null;
        }
    }
}
