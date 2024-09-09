using Ecommerce.Application.Common.Extentions;
using Ecommerce.Application.Common.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {

        private readonly IStringLocalizer<SharedResources> _localization;

        public AddProductValidator(IStringLocalizer<SharedResources> localization)
        {
            _localization = localization;
            ApplayValidationRules();
        }

        public void ApplayValidationRules()
        {
            // ProductName Name
            RuleFor(p => p.Name)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd])
                .HasLengthWithinRange(3, 20)
                .WithMessage(_localization[SharedResourcesKeys.MaxLength_100_MinLength_3]);


            // Product Price
            RuleFor(p => p.Price)
                 .IsWithinRange(3, 10000)
                 .WithMessage(_localization[SharedResourcesKeys.MaxPrice_10000_MinPrice_3]);

            // CategoryId Rules
            RuleFor(p => p.CategoryId)
                .NotNull()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);
        }

    }
}
