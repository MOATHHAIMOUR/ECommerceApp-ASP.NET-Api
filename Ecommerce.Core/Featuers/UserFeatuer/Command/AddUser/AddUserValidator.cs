using Ecommerce.Application.Common.Extentions;
using Ecommerce.Application.Common.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.AddUser
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localization;
        public AddUserValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _localization = stringLocalizer;
            ApplayValidationRules();
        }

        private void ApplayValidationRules()
        {
            RuleFor(p => p.FullName)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);


            RuleFor(p => p.UserName)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);


            RuleFor(p => p.Address)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);

            RuleFor(p => p.Email)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd])
                .Matches("^[\\w\\.-]+@[a-zA-Z\\d\\.-]+\\.[a-zA-Z]{2,}$")
                .WithMessage("You should enter a valid email ex:name@mail.com");


            RuleFor(p => p.Country)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);

            RuleFor(p => p.Passworde)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd]);

            RuleFor(p => p.ConfirmPassword)
                .NotNullOrEmpty()
                .WithMessage(_localization[SharedResourcesKeys.Requierd])
                .Equal(p => p.Passworde)
                .WithMessage(_localization[SharedResourcesKeys.Not_Equal_password_Confirm_Password]);
        }
    }
}
