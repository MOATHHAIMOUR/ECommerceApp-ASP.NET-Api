using Ecommerce.Application.Common.Enums;
using Ecommerce.Application.Common.Helpers;
using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Extentions
{
    public static class QueryableExtensions
    {

        public static IQueryable<T> ToPaginated<T>(this IQueryable<T> query, int pageNumber, int pageSize)
           where T : class
        {

            if (query == null)
            {
                throw new Exception("Empty");
            }

            //set defualt values
            pageNumber = pageNumber == 0 ? 1 : pageNumber;

            pageSize = pageSize == 0 ? 10 : pageSize;

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return query;
        }

        public static IQueryable<T> CustomFiltering<T>(this IQueryable<T> query, Dictionary<string, string> PropertyPerValue) where T : class
        {

            if (query == null)
                throw new ArgumentNullException("source");

            if (PropertyPerValue == null || !PropertyPerValue.Any())
                return query;


            // Create a parameter for the lambda expression: (T p)
            ParameterExpression parameter = Expression.Parameter(typeof(T), "Object Type");

            // Initialize the base expression with `true` to start combining
            Expression combinedExpression = Expression.Constant(true);

            foreach (var property in PropertyPerValue)
            {
                //Ex: (Product p) => p.name == 'laptop' && p.categoery == 'categoery'
                Expression filterExpression = UtilityHelper.BuildEqualityFilterExpression<T>(parameter, property.Key, property.Value);

                combinedExpression = Expression.AndAlso(combinedExpression, filterExpression);
            }

            // Build the full lambda expression: (T p) => combinedExpression
            var finalExpression = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

            // Apply the final expression in a single Where clause
            return query.Where(finalExpression);
        }

        public static IQueryable<T> CustomOrdering<T>(this IQueryable<T> query, Dictionary<string, string> propertyOrderMappings)
           where T : class
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (propertyOrderMappings == null || !propertyOrderMappings.Any())
                return query;

            IOrderedQueryable<T> orderedQuery = null;

            foreach (var property in propertyOrderMappings)
            {
                // Build order expression
                var orderByExpression = UtilityHelper.BuildOrderExpression<T>(property.Key);
                if (!Enum.TryParse(property.Value, true, out OrderType orderType))
                    throw new ArgumentException($"Invalid order type: {property.Value}");

                if (orderedQuery == null)
                {
                    // Initial sorting
                    orderedQuery = orderType == OrderType.ASC
                        ? query.OrderBy(orderByExpression)
                        : query.OrderByDescending(orderByExpression);
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


    }
}
