using Ecommerce.Application.Common.Extentions;
using FluentValidation;

namespace Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.SignIn
{
    public class SignInCommandValidator : AbstractValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            ApplayValidationRules();
        }
        public void ApplayValidationRules()
        {
            // ProductNamaae Name
            RuleFor(p => p.Username)
                .NotNullOrEmpty()
                .WithMessage("username could not be blank");


            // Product Price
            RuleFor(p => p.Password)
                .NotNullOrEmpty()
                .WithMessage("username could not be blank");
        }

    }
}
