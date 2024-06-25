using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class ServiceName
{
    public int ServiceNameId { get; set; }

    public string? ServiceName1 { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();
}
