using Ecommerce.Application.Common.Extentions;
using FluentValidation;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.UpdateProductById
{
    public class UpdateStudentValidator : AbstractValidator<UpdateProductByIdCommand>
    {
        public UpdateStudentValidator()
        {
            ApplayValidationRules();
        }

        public void ApplayValidationRules()
        {

            // ProductName Name
            RuleFor(p => p.Id)
               .GreaterThan(0).WithMessage("Invalid {PropertyName}, {PropertyName} Should be grater 0");

            // ProductName Name
            RuleFor(p => p.Name)
                .NotNullOrEmpty()
                .HasLengthWithinRange(3, 20);

            // Product Price
            RuleFor(p => p.Price)
                .IsWithinRange(20, 10000);

            // CategoryId Rules
            RuleFor(p => p.CategoryId)
               .GreaterThan(0).WithMessage("Invalid {PropertyName}, {PropertyName} Should be grater 0");
        }
    }
}
