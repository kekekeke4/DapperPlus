﻿using System;
using System.Collections.Specialized;



namespace LinqToDB.DataProvider.SQLite
{
	using System.Collections.Generic;
	using Configuration;

	//[UsedImplicitly]
	class SQLiteFactory: IDataProviderFactory
	{
		IDataProvider IDataProviderFactory.GetDataProvider(IEnumerable<NamedValue> attributes)
		{
			return new SQLiteDataProvider();
		}
	}
}
