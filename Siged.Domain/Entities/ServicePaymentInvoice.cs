using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class ServicePaymentInvoice
{
    public int ServiceInvoiceId { get; set; }

    public int? UserId { get; set; }

    public string? InvoiceNumber { get; set; }

    public int? ServiceNameId { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? AppliedTaxesId { get; set; }

    public int? DiscountsId { get; set; }

    public string? ServiceConsumedDetails { get; set; }

    public int? PaymentServiceInvoiceStatusId { get; set; }

    public virtual AppliedTaxis? AppliedTaxes { get; set; }

    public virtual Discount? Discounts { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual PaymentServiceInvoiceStatus? PaymentServiceInvoiceStatus { get; set; }

    public virtual ServiceName? ServiceName { get; set; }

    public virtual UserInfo? User { get; set; }
}
