using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Labo4ka7
{
    public static class DynamicOrder
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = Expression.Property(parameterExpression, propertyName);
            var resultExpression = Expression.Lambda(propertyExpression, parameterExpression);

            var lambda = resultExpression.Compile();

            Type enumerableType = typeof(Enumerable);
            var methods = enumerableType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var selectedMethods = methods.Where(m => m.Name == "OrderBy" && m.GetParameters().Count() == 2);

            var method = selectedMethods.First();

            method = method.MakeGenericMethod(typeof(T), propertyExpression.Type);

            var result = (IEnumerable<T>)method.Invoke(null, new object[] { source, lambda });
            return result;
        }
        public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression propertyExpression = Expression.Property(parameterExpression, propertyName);
            var resultExpression = Expression.Lambda(propertyExpression, parameterExpression);

            var lambda = resultExpression.Compile();

            Type enumerableType = typeof(Enumerable);
            var methods = enumerableType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            var selectedMethods = methods.Where(m => m.Name == "OrderByDescending" && m.GetParameters().Count() == 2);

            var method = selectedMethods.First();

            method = method.MakeGenericMethod(typeof(T), propertyExpression.Type);

            var result = (IEnumerable<T>)method.Invoke(null, new object[] { source, lambda });
            return result;
        }
    }
}
