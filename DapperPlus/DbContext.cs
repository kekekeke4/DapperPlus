using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dapper;
using DapperPlus.Sql;

namespace DapperPlus
{
    public abstract class DbContext:IDisposable
    {
        protected ISqlBuilder sqlBuilder;
        protected ISqlAdapter sqlAdapter;

        protected DbContext()
        {
            Initialize();
        }

        protected DbContext(string connectionString) : this()
        {
            ConnectionString = connectionString;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Disposed = true;
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public string ConnectionString
        {
            get;
            set;
        }

		public bool Disposed
		{
			get;
			private set;
		}

        public int Insert<T>(T entity, bool transaction = false) where T : class
        {
            IDbConnection conn = null;
            try
            {
                string sql = sqlBuilder.BuildInsert(typeof(T));
                conn = ForkConnection();
                return conn.Execute(sql, entity);
            }
            finally
            {
                ExecCompleted(conn);
            }
        }

        public int Delete<T>(T entity, bool transaction = false) where T : class
        {
            return 0;
        }

        public int Delete<T>(T entity, Expression<Func<T, object>> columns) where T : class
        {
            return 0;
        }

        public int Update<T>(T entity, Expression<Func<T, object>> columns = null) where T : class
        {
            return 0;
        }

        protected abstract IDbConnection ForkConnection(int timeout=0);

        protected abstract ISqlAdapter CreateSqlAdapter();

        protected void AssertDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("DbContext");
            }
        }

        protected virtual void ExecCompleted(IDbConnection conn)
        {
        }

        private void Initialize()
        {
            sqlAdapter = CreateSqlAdapter();
            sqlBuilder = new DefaultSqlBuilder(sqlAdapter);
        }
    }
}
