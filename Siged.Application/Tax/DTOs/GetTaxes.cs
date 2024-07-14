using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Tax.DTOs
{
    public class GetTaxes
    {
        public int TaxId { get; set; }
        public string? TaxName { get; set; }
        public int? PercentageId { get; set; }
        public string TaxPercentage { get; set; } // Cambiado a string
        public int? SalaryId { get; set; }
        public string SalaryAmount { get; set; } // Cambiado a string
        public string? NetSalary { get; set; }

    }
}
