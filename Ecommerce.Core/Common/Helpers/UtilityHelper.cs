using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Helpers
{
    public static class UtilityHelper
    {
        public static Dictionary<string, string> ConstructDic(string SearchString)
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            // // Id DESE,Name DESE
            string[] PropsPerValuesArray = SearchString.Split(',');

            foreach (string PropPerValue in PropsPerValuesArray)
            {
                // Id DESE
                string[] PropPerValueArray = PropPerValue.Split(' ');
                //Id
                string Prop = PropPerValueArray[0];
                //DESE
                string Value = PropPerValueArray[1];

                keyValuePairs.Add(Prop, Value);
            }

            return keyValuePairs;
        }

        public static Expression BuildEqualityFilterExpression<T>(ParameterExpression parameter, string FilterBy, string FilterValue)
        {

            //Extract PropertyName from the object T 
            MemberExpression propertAccsessFilterBy = Expression.Property(parameter, FilterBy);

            if (propertAccsessFilterBy == null)
                throw new ArgumentException($"Property '{FilterBy}' does not exist on type '{typeof(T)}'.");

            // convert the Filter value to propper value type from PropertyName 
            object Filter_Value = Convert.ChangeType(FilterValue, propertAccsessFilterBy.Type);

            // 'laptop'
            Expression FilterByValue = Expression.Constant(Filter_Value);

            // p.name == 'laptop'
            return Expression.Equal(propertAccsessFilterBy, FilterByValue);
        }

        public static Expression<Func<T, object>> BuildOrderExpression<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "obj");
            MemberExpression propertyAccess = Expression.Property(parameter, propertyName);
            UnaryExpression convertProperty = Expression.Convert(propertyAccess, typeof(object));

            return Expression.Lambda<Func<T, object>>(convertProperty, parameter);
        }
    }
}
