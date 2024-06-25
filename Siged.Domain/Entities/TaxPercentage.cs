using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class TaxPercentage
{
    public int PercentageId { get; set; }

    public decimal? PercentageTax { get; set; }

    public virtual ICollection<Taxis> Taxes { get; } = new List<Taxis>();
}
