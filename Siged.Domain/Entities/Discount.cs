using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Discount
{
    public int DiscountsId { get; set; }

    public string? ServiceDiscount { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();
}
