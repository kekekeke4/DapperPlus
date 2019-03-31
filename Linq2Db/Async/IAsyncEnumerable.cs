using System;

namespace LinqToDB.Async
{
	/// <summary>
	/// Asynchronous version of the IEnumerable&lt;T&gt; interface, allowing elements of the
	/// enumerable sequence to be retrieved asynchronously.
	/// </summary>
	/// <typeparam name="T">Element type.</typeparam>
	public interface IAsyncEnumerable<out T>
	{
		/// <summary>
		/// Gets an asynchronous enumerator over the sequence.
		/// </summary>
		/// <returns>Enumerator for asynchronous enumeration over the sequence.</returns>
		IAsyncEnumerator<T> GetEnumerator();
	}
}
