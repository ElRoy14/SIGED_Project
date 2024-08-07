using Siged.Application.ServicePaymentInvoices.Generators;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.DTOs
{
    public class CreateServicePaymentInvoice
    {
        public int? UserId { get; set; }
        public string? InvoiceNumber { get; private set; }
        public int? ServiceNameId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? AppliedTaxesId { get; set; }
        public int? DiscountsId { get; set; }
        public string? ServiceConsumedDetails { get; set; }
        public int? PaymentServiceInvoiceStatusId { get; set; }

        public CreateServicePaymentInvoice()
        {
            InvoiceNumber = InvoiceNumberGenerator.GetNextInvoiceNumber();
        }

    }

}
