using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Salary
{
    public int SalaryId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Taxis> Taxes { get; } = new List<Taxis>();
}
