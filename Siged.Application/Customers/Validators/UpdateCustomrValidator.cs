using FluentValidation;
using Siged.Application.Customers.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Customers.Validators
{
    public class UpdateCustomrValidator : AbstractValidator<UpdateCustomer>
    {

        public UpdateCustomrValidator() {

            RuleFor(customer => customer.IdentificationCard)
               .NotEmpty().WithMessage("La cédula es requerida")
               .Matches(@"^[0-9]*$").WithMessage("La cédula no acepta letras, solo números");

            RuleFor(customer => customer.PhoneNumber)
                    .NotEmpty().WithMessage("El teléfono es requerido")
                    .Matches(@"^[0-9]*$").WithMessage("El teléfono no acepta letras, solo números");

            RuleFor(customer => customer.FullName)
                    .NotEmpty().WithMessage("El nombre completo es requerido")
                    .MaximumLength(50).WithMessage("El nombre completo no puede exceder los 50 caracteres");

            RuleFor(customer => customer.Email)
                    .NotEmpty().WithMessage("El correo electrónico es requerido")
                    .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres");

            // Aquí puedes agregar más reglas de validación según sea necesario para otras propiedades de Customer.

        }

    }
}
