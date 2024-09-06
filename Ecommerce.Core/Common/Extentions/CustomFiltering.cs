using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Extentions
{
    public static class CustomFilteringExtensions
    {
        public static IQueryable<T> CustomFiltering<T>
            (this IQueryable<T> query, Dictionary<string, string> PropertyPerValue)
            where T : class
        {

            if (query == null)
                throw new ArgumentNullException("source");

            if (PropertyPerValue == null || !PropertyPerValue.Any())
                return query;

            // name laptop , categoery elctronic
            // (Product p) => p.name == 'laptop' && p.categoery == 'categoery'

            foreach (var property in PropertyPerValue)
            {
                Expression<Func<T, bool>> ExpressionBuilder = BuildFilterExpression<T>(property.Key, property.Value);
                query = query.Where(ExpressionBuilder);
            }

            return query;
        }


        public static Expression<Func<T, bool>> BuildFilterExpression<T>(string FilterBy, string FilterValue)
        {
            //(T object)
            // Build Prameter
            ParameterExpression prameter = Expression.Parameter(typeof(T), "Object Type");

            //Extract PropertyName from the object T 
            MemberExpression propertAccsessFilterBy = Expression.Property(prameter, FilterBy);

            // convert the Filter value to propper value type from PropertyName 
            object Filter_Value = Convert.ChangeType(FilterValue, propertAccsessFilterBy.Type);

            // 'laptop'
            Expression FilterByValue = Expression.Constant(Filter_Value);

            // p.name == 'laptop'
            BinaryExpression Equaltiy = Expression.Equal(propertAccsessFilterBy, FilterByValue);

            //Build Lambda Expression<Func<T,bool>>
            //final: (Product p) => p.name == 'laptop' && p.categoery == 'categoery'
            return Expression.Lambda<Func<T, bool>>(Equaltiy, prameter);
        }
    }
}
