using FluentValidation;
using Siged.Application.TaskEmployees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Validators
{
    public class UpdateTaskValidators : AbstractValidator<UpdateTask>
    {
        public UpdateTaskValidators() 
        {

            RuleFor(user => user.NameTask)
                .NotEmpty().WithMessage("El nombre de la taraea es requerida")
                .MaximumLength(100).WithMessage("El nombre de la taraea no puede exceder los 100 caracteres");

            RuleFor(user => user.UserId)
                .NotEmpty().WithMessage("El ID del usurio es requerido")
                .WithMessage("La usuario no acepta letras, solo números");



        }
    }
}
