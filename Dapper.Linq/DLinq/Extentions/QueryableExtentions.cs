using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace System.Data.Linq
{
    public static class QueryableExtentions
    {
        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TResult>(this IQueryable<TOuter> outer, IQueryable<TInner> inner, Expression<Func<TOuter, TInner, bool>> predicate, Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            return Join(outer, inner, SqlJoinType.LeftOuter, predicate, resultSelector);
        }

        public static IQueryable<TResult> RightJoin<TOuter, TInner, TResult>(this IQueryable<TOuter> outer, IQueryable<TInner> inner, Expression<Func<TOuter, TInner, bool>> predicate, Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            return Join(outer, inner, SqlJoinType.RightOuter, predicate, resultSelector);
        }

        public static IQueryable<TResult> FullJoin<TOuter, TInner, TResult>(this IQueryable<TOuter> outer, IQueryable<TInner> inner, Expression<Func<TOuter, TInner, bool>> predicate, Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            return Join(outer, inner, SqlJoinType.Full, predicate, resultSelector);
        }

        public static IQueryable<TResult> Join<TOuter, TInner, TResult>(this IQueryable<TOuter> outer, IQueryable<TInner> inner, SqlJoinType joinType, Expression<Func<TOuter, TInner, bool>> predicate, Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            var expr = Expression.Call(null,
                MethodHelper.GetMethodInfo(Join, outer, inner, joinType, predicate, resultSelector),
                new[]
                {
                    outer.Expression,
                    inner.Expression,
                    Expression.Constant(joinType),
                    Expression.Quote(predicate),
                    Expression.Quote(resultSelector)
                });

            return outer.Provider.CreateQuery<TResult>(expr);
        }
    }

    internal static class MethodHelper
    {
        public static MethodInfo GetMethodInfo<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> f, T1 unused1, T2 unused2, T3 unused3, T4 unused4, T5 unused5)
        {
            return f.GetMethodInfo();
        }
    }
}
