using System;
using System.Linq.Expressions;


namespace LinqToDB
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public class ExpressionMethodAttribute : Attribute
	{
		/// <summary>
		/// Creates instance of attribute.
		/// </summary>
		/// <param name="methodName">Name of method in the same class that returns substitution expression.</param>
		public ExpressionMethodAttribute( string methodName)
		{
			if (string.IsNullOrEmpty(methodName))
				throw new ArgumentException("Value cannot be null or empty.", nameof(methodName));
			MethodName = methodName;
		}

		/// <summary>
		/// Creates instance of attribute.
		/// </summary>
		/// <param name="expression">Substitution expression.</param>
		public ExpressionMethodAttribute( LambdaExpression expression)
		{
			Expression = expression ?? throw new ArgumentNullException(nameof(expression));
		}

		/// <summary>
		/// Creates instance of attribute.
		/// </summary>
		/// <param name="configuration">Connection configuration, for which this attribute should be taken into account.</param>
		/// <param name="methodName">Name of method in the same class that returns substitution expression.</param>
		public ExpressionMethodAttribute(string configuration, string methodName)
		{
			Configuration = configuration;
			MethodName    = methodName;
		}

		/// <summary>
		/// Mapping schema configuration name, for which this attribute should be taken into account.
		/// <see cref="ProviderName"/> for standard names.
		/// Attributes with <c>null</c> or empty string <see cref="Configuration"/> value applied to all configurations (if no attribute found for current configuration).
		/// </summary>
		public string Configuration { get; set; }

		/// <summary>
		/// Name of method in the same class that returns substitution expression.
		/// </summary>
		public string MethodName    { get; set; }

		/// <summary>
		/// Substitution expression.
		/// </summary>
		public LambdaExpression Expression { get; set; }

		/// <summary>
		/// Gets or sets calculated column flag. When applied to property and set to <c>true</c>, Linq To DB will
		/// load data into property using expression during entity materialization.
		/// </summary>
		public bool IsColumn { get; set; }

	}
}
