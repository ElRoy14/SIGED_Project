using FluentValidation;
using Siged.Application.TaskEmployees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Validators
{
    public class UpdateStateValidator : AbstractValidator<UpdateStateTask>
    {
        public UpdateStateValidator() 
        {

            RuleFor(state => state.TaskStatusId)
                .NotEmpty().WithMessage("The state ID is required")
                .InclusiveBetween(1, 3).WithMessage("The state must be between 1 and 2");

        }
    }
}
