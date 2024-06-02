using FluentValidation;
using Siged.Application.Users.DTOs;

namespace Siged.Application.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.IdentificationCard)
                .NotEmpty().WithMessage("The identification card is required")
                .MaximumLength(50).WithMessage("The identification card cannot exceed 50 characters");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("The phone number is required")
                .MaximumLength(15).WithMessage("The phone number cannot exceed 15 characters");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("The full name is required")
                .MaximumLength(50).WithMessage("The full name cannot exceed 50 characters");


            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("The email is required")
                .MaximumLength(100).WithMessage("The email cannot exceed 100 characters");

            RuleFor(user => user.UserPassword)
                .NotEmpty().WithMessage("The password is required")
                .MaximumLength(100).WithMessage("The password cannot exceed 100 characters");

            RuleFor(user => user.RolId)
                .NotEmpty().WithMessage("The role ID is required")
                .InclusiveBetween(1, 3).WithMessage("The role must be between 1 and 4");

            RuleFor(user => user.JobTitleId)
                .NotEmpty().WithMessage("The role ID is required")
                .InclusiveBetween(1, 5).WithMessage("The JobTitle must be between 1 and 4");

            RuleFor(user => user.DepartmentId)
                .NotEmpty().WithMessage("The role ID is required")
                .InclusiveBetween(1, 4).WithMessage("The Department must be between 1 and 4");

            RuleFor(user => user.SalaryId)
                .NotEmpty().WithMessage("The role ID is required")
                .InclusiveBetween(1, 4).WithMessage("The Salary must be between 1 and 4");

            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("The active state is required")
                .InclusiveBetween(0, 1).WithMessage("The state must be between 0 and 1");

        }

    }

}
