using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class AppliedTaxis
{
    public int AppliedTaxesId { get; set; }

    public string? TaxToApply { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();
}
