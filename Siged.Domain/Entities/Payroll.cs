using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public int? UserId { get; set; }

    public string? PaymentDate { get; set; }

    public int? TaxId { get; set; }

    public virtual Taxis? Tax { get; set; }

    public virtual UserInfo? User { get; set; }
}
