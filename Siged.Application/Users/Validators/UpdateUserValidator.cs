using FluentValidation;
using Siged.Application.Users.DTOs;

namespace Siged.Application.Users.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.IdentificationCard)
    .NotEmpty().WithMessage("La cédula es requerida")
    .Matches(@"^[0-9]*$").WithMessage("La cédula no acepta letras, solo números");

            RuleFor(user => user.PhoneNumber)
                .NotEmpty().WithMessage("El teléfono es requerido")
                .Matches(@"^[0-9]*$").WithMessage("El teléfono no acepta letras, solo números");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("El nombre completo es requerido")
                .MaximumLength(50).WithMessage("El nombre completo no puede exceder los 50 caracteres");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres");

            RuleFor(user => user.UserPassword)
                .NotEmpty().WithMessage("La contraseña es requerida")
                .MaximumLength(100).WithMessage("La contraseña no puede exceder los 100 caracteres");

            RuleFor(user => user.RolId)
                .NotEmpty().WithMessage("El ID del rol es requerido")
                .InclusiveBetween(1, 3).WithMessage("El rol debe estar entre 1 y 3");

            RuleFor(user => user.JobTitleId)
                .NotEmpty().WithMessage("El ID del cargo es requerido")
                .InclusiveBetween(1, 5).WithMessage("El cargo debe estar entre 1 y 5");

            RuleFor(user => user.DepartmentId)
                .NotEmpty().WithMessage("El ID del departamento es requerido")
                .InclusiveBetween(1, 4).WithMessage("El departamento debe estar entre 1 y 4");


            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("El estado activo es requerido")
                .InclusiveBetween(0, 1).WithMessage("El estado debe estar entre 0 y 1");

        }

    }

}
