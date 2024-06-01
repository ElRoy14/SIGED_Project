using FluentValidation;
using Siged.Application.Authentication.DTOs;

namespace Siged.Application.Authentication.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(request => request.UserPassword)
                .NotEmpty()
                .WithMessage("Password is required");
        }

    }

}
