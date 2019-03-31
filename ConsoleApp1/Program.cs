using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new System.Data.SqlClient.SqlConnection("Database=MingxPay;Server=118.24.48.226,7754;uid=sa;pwd=123456789Jq51RQZyrYNi*Rh2ioOrpqn1TMe9SeqkPa6bG7+9z+CtPfTk/lanRPisVt94kxSh123456789;");
            //DataConnection.DefaultSettings = new MySettings();
            //var db = new PayDb();
            var ctx = new DataContext(conn);
            var orders = ctx.GetTable<Order>();
            var accounts = ctx.GetTable<Account>();
            //orders.Where(p => p.Id > 0).up//.Set(p => p.Amount, x => x.Amount + 1).Update();

            //var query = orders.Join(accounts, o => o.Id, a => a.AccountId, (o, a) => new
            //     OrderAccount
            //{
            //    OrderId = o.Id,
            //    OrderAmout = o.Amount,
            //    Balance = a.Balance
            //});//.Where(p => p.Balance > 0).OrderByDescending(p => p.Balance).Take(0).Skip(50);

            var query = orders.RightJoin<Order, Account, OrderAccount>(accounts, (outer, inner) => (outer.AccountId == inner.AccountId && outer.Amount == inner.Balance), (outer, inner) => new OrderAccount
            {
                OrderId = outer.Id,
                OrderAmout = outer.Amount
            });
            var result = query.ToList();
            Console.WriteLine("Hello World!");
        }
    }

    //public class PayDb : DataConnection
    //{
    //    public PayDb() :
    //        base("SqlServer")
    //    {
    //    }

    //    public ITable<Order> Orders => GetTable<Order>();

    //    public ITable<Account> Accounts => GetTable<Account>();
    //}

    ////public class ConnectionStringSettings : IConnectionStringSettings
    ////{
    ////    public string ConnectionString { get; set; }
    ////    public string Name { get; set; }
    ////    public string ProviderName { get; set; }
    ////    public bool IsGlobal => false;
    ////}

    //public class MySettings : ILinqToDBSettings
    //{
    //    public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

    //    public string DefaultConfiguration => "SqlServer";
    //    public string DefaultDataProvider => "SqlServer";

    //    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    //    {
    //        get
    //        {
    //            yield return
    //                new ConnectionStringSettings
    //                {
    //                    Name = "SqlServer",
    //                    ProviderName = "SqlServer",
    //                    ConnectionString = @"Database=MingxPay;Server=118.24.48.226,7754;uid=sa;pwd=123456789Jq51RQZyrYNi*Rh2ioOrpqn1TMe9SeqkPa6bG7+9z+CtPfTk/lanRPisVt94kxSh123456789;"
    //                };
    //        }
    //    }
    //}


    [Table(Name = "tb_pay_unifiedorder")]
    public class Order
    {

        [Column(Name = "id", IsDbGenerated = true, IsPrimaryKey = true)]
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

        [Column(Name = "accountid")]
        public int AccountId
        {
            get;
            set;
        }
    }

    [Table(Name="tb_pay_wallet")]
    public class Account
    {
        //[PrimaryKey, Identity]
        [Column(Name="accountId")]
        public int AccountId
        {
            get;
            set;
        }

        [Column(Name="balance")]
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
