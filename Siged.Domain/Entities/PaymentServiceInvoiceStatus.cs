using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class PaymentServiceInvoiceStatus
{
    public int PaymentServiceInvoiceStatusId { get; set; }

    public string? ServicePaymentStatus { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();
}
