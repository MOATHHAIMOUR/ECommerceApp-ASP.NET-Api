using Ecommerce.Application.Common.Enums;
using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Extentions
{


    public static class CustomOrderingExtention
    {
        public static IQueryable<T> CustomOrdering<T>(this IQueryable<T> queryable,
        Dictionary<string, string> propertyOrderMappings)
            where T : class
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            if (propertyOrderMappings == null || !propertyOrderMappings.Any())
                return queryable;

            IOrderedQueryable<T> orderedQuery = null;

            foreach (var property in propertyOrderMappings)
            {
                // Build order expression
                var orderByExpression = BuildOrderExpression<T>(property.Key);
                if (!Enum.TryParse(property.Value, true, out OrderType orderType))
                    throw new ArgumentException($"Invalid order type: {property.Value}");

                if (orderedQuery == null)
                {
                    // Initial sorting
                    orderedQuery = orderType == OrderType.ASC
                        ? queryable.OrderBy(orderByExpression)
                        : queryable.OrderByDescending(orderByExpression);
                }
                else
                {
                    // Subsequent sorting
                    orderedQuery = orderType == OrderType.ASC
                        ? orderedQuery.ThenBy(orderByExpression)
                        : orderedQuery.ThenByDescending(orderByExpression);
                }
            }

            return orderedQuery;
        }

        private static Expression<Func<T, object>> BuildOrderExpression<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "obj");
            MemberExpression propertyAccess = Expression.Property(parameter, propertyName);
            UnaryExpression convertProperty = Expression.Convert(propertyAccess, typeof(object));

            return Expression.Lambda<Func<T, object>>(convertProperty, parameter);
        }
    }
}
