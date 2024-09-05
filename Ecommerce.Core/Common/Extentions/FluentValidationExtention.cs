using FluentValidation;

namespace Ecommerce.Application.Common.Extentions
{
    public static class FluentValidationExtention
    {

        public static IRuleBuilderOptions<T, string>
            NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(prop =>
            {
                if (!string.IsNullOrEmpty(prop))
                    return true;

                return false;

            }).WithMessage("{PropertyName} must be null or empty.");
        }



        public static IRuleBuilderOptions<T, string>
            HasLengthWithinRange<T>(this IRuleBuilder<T, string> ruleBuilder,
            int smallVal, int largeVal)
        {
            return ruleBuilder.Must(str =>
            {
                return str.Length >= smallVal && str.Length <= largeVal;

            }).WithMessage("{PropertyName} must be between " + smallVal + " and " + largeVal + " characters long.");

        }



        public static IRuleBuilderOptions<T, TProperty>
            IsWithinRange<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
            TProperty smallVal, TProperty largeVal)
                where TProperty : struct, IComparable<TProperty>
        {
            return ruleBuilder.Must(num =>
            {
                return num.CompareTo(smallVal) >= 0 && num.CompareTo(largeVal) <= 0;

            }).WithMessage("{PropertyName} must be between " + smallVal + " and " + largeVal + " Range.");

        }

    }
}
