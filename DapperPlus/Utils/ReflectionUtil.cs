using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DapperPlus
{
    public static class ReflectionUtil
    {
		public static MemberInfo GetProperty(LambdaExpression lambda)
		{
			Expression expression = lambda;
			for (;;)
			{
				switch (expression.NodeType)
				{
					case ExpressionType.Lambda:
						expression = ((LambdaExpression)expression).Body;
						break;
					case ExpressionType.Convert:
						expression = ((UnaryExpression)expression).Operand;
						break;
					case ExpressionType.MemberAccess:
						MemberExpression memberExpression = (MemberExpression)expression;
						MemberInfo mi = memberExpression.Member;
						return mi;
					default:
						return null;
				}
			}
		}
    }
}
