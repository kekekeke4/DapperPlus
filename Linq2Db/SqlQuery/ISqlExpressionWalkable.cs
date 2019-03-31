using System;

namespace LinqToDB.SqlQuery
{
	public class WalkOptions
	{
		public bool SkipColumns;

		public bool ProcessParent;

		public WalkOptions()
		{
		}

		public WalkOptions(bool skipColumns)
		{
			SkipColumns = skipColumns;
		}
	}

	public interface ISqlExpressionWalkable
	{
		ISqlExpression Walk(WalkOptions options, Func<ISqlExpression, ISqlExpression> func);
	}
}
