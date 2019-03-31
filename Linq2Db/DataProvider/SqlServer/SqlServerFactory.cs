using System;
using System.Collections.Specialized;



namespace LinqToDB.DataProvider.SqlServer
{
	using System.Collections.Generic;
	using System.Linq;

	using Configuration;

	//[UsedImplicitly]
	class SqlServerFactory : IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(IEnumerable<NamedValue> attributes)
		{
			var version = attributes.FirstOrDefault(_ => _.Name == "version");
			if (version != null)
			{
				switch (version.Value)
				{
					case "2000": return new SqlServerDataProvider(ProviderName.SqlServer2000, SqlServerVersion.v2000);
					case "2005": return new SqlServerDataProvider(ProviderName.SqlServer2005, SqlServerVersion.v2005);
					case "2012": return new SqlServerDataProvider(ProviderName.SqlServer2012, SqlServerVersion.v2012);
					case "2014": return new SqlServerDataProvider(ProviderName.SqlServer2014, SqlServerVersion.v2012);
				}
			}

			return new SqlServerDataProvider(ProviderName.SqlServer2008, SqlServerVersion.v2008);
		}
	}
}
