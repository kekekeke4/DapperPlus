﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using DapperPlus.Utils;

namespace DapperPlus
{
    public abstract class PooledDbContext : DbContext
    {
        private readonly int DEFAULT_MAX_CONNS = 5;
        private readonly ConcurrentChannel<IDbConnection> idls; // useable connetions
        private readonly ConcurrentChannel<IDbConnection> activities; // using connections;
        private int maxConn;
        private int alloced;

        protected PooledDbContext(string connString) : base(connString)
        {
            idls = new ConcurrentChannel<IDbConnection>();
            activities = new ConcurrentChannel<IDbConnection>();
        }

		public int MaxConnection
		{
			get
			{
				if (maxConn <= 0)
				{
					return DEFAULT_MAX_CONNS;
				}
				return maxConn;
			}
			set
			{
				if (value <= 0)
				{
					maxConn = DEFAULT_MAX_CONNS;
				}
			}
		}

        protected override IDbConnection ForkConnection(int timeout = 0)
        {
            IDbConnection conn = null;
            if (alloced >= MaxConnection)
            {
                conn = idls.Read(timeout);
                activities.Write(conn);
                return conn;
            }

        _LOOP:
            if (idls.TryRead(ref conn))
            {
                // if the connection offline try loop get
                if (conn.State == ConnectionState.Closed)
                {
                    Free(conn);
                    goto _LOOP;
                }
                activities.Write(conn);
                return conn;
            }
            conn = Alloc();
            activities.Write(conn);
            return conn;
        }

        protected override void Dispose(bool disposing)
        {
            idls.CompleteWrite();
            activities.CompleteWrite();
            FreeConnections(idls);
            FreeConnections(activities);
            base.Dispose(disposing);
        }

        protected override void ExecCompleted(IDbConnection conn)
        {
            base.ExecCompleted(conn);
            activities.Remove(conn);
            if (conn.State == ConnectionState.Closed)
            {
                Free(conn); // if conn is closed then free the conn
            }
            else
            {
                idls.Write(conn); // put to idls.
            }
        }

        protected IDbConnection Alloc(bool open = true)
        {
            IDbConnection conn = sqlAdapter.CreateConnection(ConnectionString);
            if (open)
            {
                conn.Open();
            }
            alloced = Interlocked.Increment(ref alloced);
            return conn;
        }

        protected void Free(IDbConnection conn)
        {
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                alloced = Interlocked.Decrement(ref alloced);
            }
        }

        protected void FreeConnections(ConcurrentChannel<IDbConnection> conns)
        {
            IDbConnection conn=null;
            while (conns.TryRead(ref conn))
            {
                Free(conn);
            }
        }
    }


}
