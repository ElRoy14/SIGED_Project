using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.DTOs
{
    public class GetServicePaymentInvoice
    {
        public int ServiceInvoiceId { get; set; }
        public int? UserId { get; set; }
        public string? UserDescription { get; set; }
        public string? InvoiceNumber { get; set; }
        public int? ServiceNameId { get; set; }
        public string? ServiceDescription { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? PaymentDescription { get; set; }
        public int? AppliedTaxesId { get; set; }
        public string? AppliedDescription { get; set; }
        public int? DiscountsId { get; set; }
        public string? DiscountsDescription { get; set; }
        public string? ServiceConsumedDetails { get; set; }
        public int? PaymentServiceInvoiceStatusId { get; set; }
        public string? PaymentServiceInvoiceStatusDescription { get; set; }

    }

}
