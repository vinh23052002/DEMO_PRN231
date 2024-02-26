using FluentValidation;
using FluentValidationDemo.Models;

namespace FluentValidationDemo.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Account)
                .NotEmpty()
                .NotNull().WithMessage("Account is required")
                .EmailAddress()
                .Length(6, 12);
            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull().WithMessage("Password is required")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull().WithMessage("Name is required");

            RuleFor(p => p.Address)
                .Must(p => p.Contains("street") == true).WithMessage("Address must contrain street");
        }
    }
}
