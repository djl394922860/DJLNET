using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Extension
{
    public static class ExpressionExtensions
    {
        public static Expression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }
        public static Expression Call(this Expression instance, string methodName, params Expression[] arguments)
        {
            return Expression.Call(instance, instance.Type.GetMethod(methodName), arguments);
        }
        public static Expression Property(this Expression expression, string propertyName)
        {
            return Expression.Property(expression, propertyName);
        }
        public static Expression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }
        public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body, params ParameterExpression[] parameters)
        {
            return Expression.Lambda<TDelegate>(body, parameters);
        }

        #region 示例代码

        //Expression<Func<Person, bool>> exp = p => p.Name.Contains("ldp") && p.Birthday.Value.Year > 1990;

        // 未使用扩展

        //  var parameter = Expression.Parameter(typeof(Person), "p");
        //  var left = Expression.Call(
        //      Expression.Property(parameter, "Name"),
        //      typeof(string).GetMethod("Contains"),
        //      Expression.Constant("ldp"));
        //  var right = Expression.GreaterThan(
        //      Expression.Property(Expression.Property(Expression.Property(parameter, "Birthday"), "Value"), "Year"),
        //      Expression.Constant(1990));
        //  var body = Expression.AndAlso(left, right);
        //  var lambda = Expression.Lambda<Func<Person, bool>>(body, parameter);

        // 使用扩展

        //  var parameter = Expression.Parameter(typeof(Person), "p");
        //  var left = parameter.Property("Name").Call("Contains", Expression.Constant("ldp"));
        //  var right = parameter.Property("Birthday").Property("Value").Property("Year").GreaterThan(Expression.Constant(1990));
        //  var lambda = left.AndAlso(right).ToLambda<Func<Person, bool>>(parameter);

        #endregion
    }
}
