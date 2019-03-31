using System;



namespace LinqToDB.Data
{
	public class DataConnectionTransaction : IDisposable
	{
		public DataConnectionTransaction( DataConnection dataConnection)
		{
			if (dataConnection == null) throw new ArgumentNullException("dataConnection");

			DataConnection = dataConnection;
		}

		public DataConnection DataConnection { get; private set; }

		bool _disposeTransaction = true;

		public void Commit()
		{
			DataConnection.CommitTransaction();
			_disposeTransaction = false;
		}

		public void Rollback()
		{
			DataConnection.RollbackTransaction();
			_disposeTransaction = false;
		}

		public void Dispose()
		{
			if (_disposeTransaction)
				DataConnection.RollbackTransaction();
		}
	}
}
