using FluentValidation;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.DeleteProductById
{
    public class DeleteProductByIdValidator : AbstractValidator<DeleteProductByIdCommand>
    {
        public DeleteProductByIdValidator()
        {
            ApplayValidationRules();
        }


        public void ApplayValidationRules()
        {
            RuleFor(P => P.Id)
                .GreaterThan(0).WithMessage("Product Id Should be gratter than 0");
        }
    }
}
