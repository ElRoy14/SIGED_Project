using FluentValidation;
using Siged.Application.Customers.DTOs;
using Siged.Application.Suppliers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Suppliers.Validators
{
    public class CreateSupplierValidator : AbstractValidator<CreateSuppliers>
    {
        public CreateSupplierValidator() {

            RuleFor(supplier => supplier.IdentificationCard)
               .NotEmpty().WithMessage("La cédula es requerida")
               .Matches(@"^[0-9]*$").WithMessage("La cédula no acepta letras, solo números")
               .MaximumLength(11).WithMessage("La cédula no puede exceder los 11 caracteres");

            RuleFor(supplier => supplier.PhoneNumber)
                .NotEmpty().WithMessage("El teléfono es requerido")
                .Matches(@"^[0-9]*$").WithMessage("El teléfono no acepta letras, solo números");

            RuleFor(supplier => supplier.FullName)
                .NotEmpty().WithMessage("El nombre completo es requerido")
                .MaximumLength(50).WithMessage("El nombre completo no puede exceder los 50 caracteres");

            RuleFor(supplier => supplier.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .MaximumLength(100).WithMessage("El correo electrónico no puede exceder los 100 caracteres");

            // Aquí puedes agregar más reglas de validación según sea necesario para otras propiedades de Customer.

        }
    }
}
