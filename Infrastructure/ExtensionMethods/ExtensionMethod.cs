using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExtensionMethods
{
    public static class ExtensionMethod
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(rs);
        }

        public static Expression<Func<T, bool>> GenerateFilterExpression<T>(List<string> properties, string filterBy)
        {
            var parameter = Expression.Parameter(typeof(T), "m");
            var filterExpressions = new List<Expression>();

            foreach (var property in properties)
            {
                var propertyInfo = typeof(T).GetProperty(property);
                if (propertyInfo.PropertyType == typeof(string))
                {
                    var propertyExpression = Expression.Property(parameter, property);
                    var toLower = Expression.Call(propertyExpression, "ToLower", null);
                    var filterValue = Expression.Constant(filterBy.ToLower());
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var containsExpression = Expression.Call(toLower, containsMethod, filterValue);
                    filterExpressions.Add(containsExpression);
                }
                // Dodaj warunki dla innych typów właściwości, jeśli to konieczne
            }

            if (filterExpressions.Count == 0)
            {
                return m => true; // Jeśli nie ma wyrażeń filtrujących, zwróć funkcję zawsze zwracającą true
            }

            var combinedExpression = filterExpressions.Aggregate((Expression)null, (current, expression) =>
                current == null ? expression : Expression.OrElse(current, expression));

            return Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
        }
    }
}
