using EF_Project.ViewModels.UserModels;
using FluentValidation;

namespace EF_Project.Validators.UserValidation
{
    public class UserRequestModelValidator : AbstractValidator<UserRequestModel>
    {
        public UserRequestModelValidator()
        {
            RuleFor(u => u.FirstName)
                .MaximumLength(100)
                .NotNull()
                .NotEmpty()
                .WithMessage("Hajox");

            RuleFor(u => u.LastName)
                .MaximumLength(100)
                .NotNull()
                .NotEmpty()
                .WithMessage("Hajox");

            RuleFor(u => u.Email)
                .MaximumLength(80)
                .Matches(u => u.Email)
                .WithMessage("Hajox");

            RuleFor(u => u.Password)
                .MinimumLength(6)
                .MaximumLength(500)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}' must contain one or more special characters.");
        }
    }
}
