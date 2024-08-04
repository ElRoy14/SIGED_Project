using FluentValidation;
using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Validators
{
    public class CreateInvoiceValidator : AbstractValidator<CreateServicePaymentInvoice>
    {
        public CreateInvoiceValidator() 
        {

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("El campo UserId es obligatorio.");

            RuleFor(x => x.InvoiceNumber)
                .NotEmpty().WithMessage("El campo InvoiceNumber es obligatorio.")
                .Length(1, 50).WithMessage("El campo InvoiceNumber debe tener entre 1 y 50 caracteres.");

            RuleFor(x => x.ServiceNameId)
                .NotEmpty().WithMessage("El campo ServiceNameId es obligatorio.")
                .InclusiveBetween(1, 1).WithMessage("Unicamente existe un servicio y es el id 1.");

            RuleFor(x => x.PaymentMethodId)
                .NotEmpty().WithMessage("El campo PaymentMethodId es obligatorio.")
                .InclusiveBetween(1, 3).WithMessage("Los valores permitidos para PaymentMethodId son entre 1 y 3.");

            RuleFor(x => x.AppliedTaxesId)
                .NotEmpty().WithMessage("El campo AppliedTaxesId es obligatorio.")
                .InclusiveBetween(1, 3).WithMessage("Los valores permitidos para AppliedTaxesId son entre 1 y 3.");

            RuleFor(x => x.DiscountsId)
                .NotEmpty().WithMessage("El campo DiscountsId es obligatorio.")
                .InclusiveBetween(1, 3).WithMessage("Los valores permitidos para DiscountsId son entre 1 y 3.");

            RuleFor(x => x.ServiceConsumedDetails)
                .MaximumLength(100).WithMessage("El campo ServiceConsumedDetails no puede exceder los 100 caracteres.");

            RuleFor(x => x.PaymentServiceInvoiceStatusId)
                .NotEmpty().WithMessage("El campo PaymentServiceInvoiceStatusId es obligatorio.")
                .InclusiveBetween(1, 3).WithMessage("Los valores permitidos para PaymentServiceInvoiceStatusId son entre 1 y 3.");



        }
    }
}
