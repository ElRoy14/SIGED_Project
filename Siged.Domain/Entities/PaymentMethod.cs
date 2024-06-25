using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? PaymentMethod1 { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();
}
