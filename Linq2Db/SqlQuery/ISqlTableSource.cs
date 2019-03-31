using System;
using System.Collections.Generic;

namespace LinqToDB.SqlQuery
{
	public interface ISqlTableSource : ISqlExpression
	{
		/// <summary>
		/// 获取查询所有字段 *
		/// </summary>
		SqlField All { get; }

		int SourceID { get; }

		SqlTableType SqlTableType { get; }

		IList<ISqlExpression> GetKeys(bool allIfEmpty);
	}
}
