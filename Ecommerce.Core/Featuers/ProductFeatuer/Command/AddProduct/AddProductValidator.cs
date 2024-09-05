using Ecommerce.Application.Common.Extentions;
using FluentValidation;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {

        // for custom handleing
        /*        private readonly IStudentService _service;
        */
        public AddProductValidator()
        {
            ApplayValidationRules();
        }

        public void ApplayValidationRules()
        {
            // ProductName Name
            RuleFor(p => p.Name)
                .NotNullOrEmpty()
                .HasLengthWithinRange(3, 20);


            // Product Price
            RuleFor(p => p.Price)
                 .IsWithinRange(3, 20);

            // CategoryId Rules
            RuleFor(p => p.CategoryId)
               .GreaterThan(0).WithMessage("{PropertyName} must be grater than 0");

        }

        /*  //Custom Errors
          public void ApplyCustomValidationrules()
          {
        //true => no errro
        //false => throw exeption
              RuleFor(s => s.Name)
                  .MustAsync(async (Name, cancellationToken) => !(await _service.IsNameExistAsync(Name))
                  ).WithMessage("A student with the same Name is already present!");
          }*/

    }


    /*public static IRuleBuilderOptions<T, TProperty> NotEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        => ruleBuilder.SetValidator(new NotEmptyValidator<T, TProperty>());
*/

}
