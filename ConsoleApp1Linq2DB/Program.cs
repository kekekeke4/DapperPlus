using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			DataConnection.DefaultSettings = new MySettings();
			var db = new PayDb();
			db.Orders.Where(p => p.Id > 0).Set(p => p.Amount, x => x.Amount + 1).Update();
			var query = db.Orders.LeftJoin(db.Accounts, (o, a) => o.Id == a.AccountId, (o, a) => new
			OrderAccount
			{
				OrderId = o.Id,
				OrderAmout = o.Amount,
				Balance = a.Balance
			}).Where(p => p.Balance > 0).OrderByDescending(p => p.Balance);
			var result = query.ToList();
			Console.WriteLine("Hello World!");
			Console.WriteLine("Hello World!");
        }
    }

	public class PayDb : DataConnection
	{
		public PayDb() :
			base("SqlServer")
		{
		}

		public ITable<Order> Orders => GetTable<Order>();

		public ITable<Account> Accounts => GetTable<Account>();
	}

	public class ConnectionStringSettings : IConnectionStringSettings
	{
		public string ConnectionString { get; set; }
		public string Name { get; set; }
		public string ProviderName { get; set; }
		public bool IsGlobal => false;
	}

	public class MySettings : ILinqToDBSettings
	{
		public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

		public string DefaultConfiguration => "SqlServer";
		public string DefaultDataProvider => "SqlServer";

		public IEnumerable<IConnectionStringSettings> ConnectionStrings
		{
			get
			{
				yield return
					new ConnectionStringSettings
					{
						Name = "SqlServer",
						ProviderName = "SqlServer",
						ConnectionString = @"Database=MingxPay;Server=118.24.48.226,7754;uid=sa;pwd=123456789Jq51RQZyrYNi*Rh2ioOrpqn1TMe9SeqkPa6bG7+9z+CtPfTk/lanRPisVt94kxSh123456789;"
					};
			}
		}
	}


	[Table(Name = "tb_pay_unifiedorder")]
	public class Order
	{

		[PrimaryKey, Identity]
		public int Id
		{
			get;
			set;
		}

		[Column(Name = "amount")]
		public decimal Amount
		{
			get;
			set;
		}

		[Column(Name = "productid")]
		public string ProductId
		{
			get;
			set;
		}
	}

	[Table(Name = "tb_pay_wallet")]
	public class Account
	{
		[PrimaryKey, Identity]
		public int AccountId
		{
			get;
			set;
		}

		[Column("balance")]
		public decimal Balance
		{
			get;
			set;
		}
	}

	public class OrderAccount
	{
		public int OrderId
		{
			get;
			set;
		}

		public decimal OrderAmout
		{
			get;
			set;
		}
		public decimal Balance
		{
			get;
			set;
		}
	}
}
