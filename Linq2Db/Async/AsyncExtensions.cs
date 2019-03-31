using System;
using System.Linq;
using System.Threading;


namespace LinqToDB.Async
{
	using Linq;

	/// <summary>
	/// This API supports the LinqToDB infrastructure and is not intended to be used  directly from your code.
	/// This API may change or be removed in future releases.
	/// </summary>
	public static class AsyncExtensions
	{
		#region AsAsyncEnumerable

		/// <summary>
		/// This API supports the LinqToDB infrastructure and is not intended to be used  directly from your code.
		/// This API may change or be removed in future releases.
		/// </summary>
		public static IAsyncEnumerable<TSource> AsAsyncEnumerable<TSource>(
			 this IQueryable<TSource> source,
			CancellationToken                  token = default(CancellationToken))
		{
			if (source == null) throw new ArgumentNullException(nameof(source));

			if (source is ExpressionQuery<TSource> query)
				return query.GetAsyncEnumerable();

			throw new InvalidOperationException("ExpressionQuery expected.");
		}

		#endregion
	}
}
