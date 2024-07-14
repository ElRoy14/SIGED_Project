using FluentValidation;
using Siged.Application.PerformanceEvaluations.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.Validators
{
    public class UpdatePerformanceValidator : AbstractValidator<UpdatePerformanceEvaluation>
    {
        public UpdatePerformanceValidator() 
        {
            RuleFor(user => user.EvaluatorId)
                .NotEmpty().WithMessage("El id del evaluador es requerido")
                .WithMessage("La evaluador no acepta letras, solo números");

            RuleFor(user => user.GoalId)
                .NotEmpty().WithMessage("El id del la meta es requerido")
                .WithMessage("La meta no acepta letras, solo números");

            RuleFor(user => user.UserId)
                .NotEmpty().WithMessage("El id del usuario es requerido")
                .WithMessage("La usuario no acepta letras, solo números");
        }

    }

}
