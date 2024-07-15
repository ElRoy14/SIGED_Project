using FluentValidation;
using Siged.Application.Payrolls.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.Validators
{
    public class CreatePayrollValidator : AbstractValidator<CreatePayroll>
    {
        public CreatePayrollValidator()
        {

            RuleFor(user => user.UserId)
                .NotEmpty().WithMessage("El id del usuario es requerido")
                .WithMessage("La usuario no acepta letras, solo números");

            RuleFor(user => user.PaymentDate)
                .NotEmpty().WithMessage("El dia de pago es requerido")
                .WithMessage("El dia de pago no acepta letras, solo números");

            RuleFor(user => user.TaxId)
                .NotEmpty().WithMessage("El salario es requerido")
                .WithMessage("El salario no acepta letras, solo números");


        }
    }
}
