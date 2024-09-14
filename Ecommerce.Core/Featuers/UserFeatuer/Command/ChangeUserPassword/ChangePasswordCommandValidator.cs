using FluentValidation;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.ChangeUserPassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            ApplayValidationRules();
        }

        private void ApplayValidationRules()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Password Id requierd");

            RuleFor(p => p.CurrentPassword)
                .NotNull()
                .WithMessage("CurrentPassword is requierd");

            RuleFor(p => p.NewPassword)
                .NotNull()
                .WithMessage("NewPassword is requierd");

            RuleFor(p => p.ConfirmPassword)
                .NotNull()
                .WithMessage("ConfirmPassword is requierd")
                .Equal(p => p.NewPassword);
        }
    }
}
