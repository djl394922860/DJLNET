using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Extension
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, false);
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName, bool desc)
        {
            return QueryableHelper<T>.OrderBy(queryable, propertyName, desc);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<T> Include<T, TInclude>(this IQueryable<T> query, Expression<Func<T, TInclude>> path) where T : class where TInclude : class
        {
            if (query is System.Data.Entity.Core.Objects.ObjectSet<T>)
            {
                //Entity Framework
                Int32 i = path.Body.ToString().IndexOf('.');
                String pathString = path.Body.ToString().Substring(i + 1);
                return ((query as System.Data.Entity.Core.Objects.ObjectSet<T>).Include(pathString));
            }
            else
            {
                //LINQ to SQL and others
                ParameterExpression pathParameter = path.Parameters.Single();
                Type tupleType = typeof(Tuple<T, TInclude>);
                Expression<Func<T, Tuple<T, TInclude>>> pathSelector = Expression.Lambda<Func<T, Tuple<T, TInclude>>>(Expression.New(tupleType.GetConstructor(new Type[] { typeof(T), typeof(TInclude) }), new Expression[] { pathParameter, path.Body }, tupleType.GetProperty("Item1"), tupleType.GetProperty("Item2")), pathParameter);
                return (query.Select(pathSelector).Select(t => new { Item1 = t.Item1, Item2 = t.Item2 }).Select(t => t.Item1));
            }
        }

        static class QueryableHelper<T>
        {
            private static Dictionary<string, LambdaExpression> cache = new Dictionary<string, LambdaExpression>();
            public static IQueryable<T> OrderBy(IQueryable<T> queryable, string propertyName, bool desc)
            {
                dynamic keySelector = GetLambdaExpression(propertyName);
                return desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
            }
            private static LambdaExpression GetLambdaExpression(string propertyName)
            {
                if (cache.ContainsKey(propertyName)) return cache[propertyName];
                var param = Expression.Parameter(typeof(T));
                var body = Expression.Property(param, propertyName);
                var keySelector = Expression.Lambda(body, param);
                cache[propertyName] = keySelector;
                return keySelector;
            }
        }
    }
}
