﻿using System;


namespace LinqToDB.Common
{
	/// <summary>
	/// Empty array instance helper.
	/// </summary>
	/// <typeparam name="T">Array element type.</typeparam>
	public static class Array<T>
	{
		/// <summary>
		/// Static instance of empty array of specific type.
		/// </summary>
		public static readonly T[] Empty = new T[0];
	}
}
