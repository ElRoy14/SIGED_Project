using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Taxis
{
    public int TaxId { get; set; }

    public string? TaxName { get; set; }

    public int? PercentageId { get; set; }

    public int? SalaryId { get; set; }

    public string? NetSalary { get; set; }

    public virtual ICollection<Payroll> Payrolls { get; } = new List<Payroll>();

    public virtual TaxPercentage? Percentage { get; set; }

    public virtual Salary? Salary { get; set; }
}
