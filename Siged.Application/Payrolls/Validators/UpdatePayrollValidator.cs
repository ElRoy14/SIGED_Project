using FluentValidation;
using Siged.Application.Payrolls.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.Validators
{
    public class UpdatePayrollValidator : AbstractValidator<UpdatePayroll>
    {
        public UpdatePayrollValidator() 
        {
            RuleFor(user => user.TaxId)
                .NotEmpty().WithMessage("El salario es requerido")
                .WithMessage("El salario no acepta letras, solo números");

        }
    }
}
