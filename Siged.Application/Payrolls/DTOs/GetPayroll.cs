using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.DTOs
{
    public class GetPayroll
    {
        public int PayrollId { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PaymentDate { get; set; }
        public int? TaxId { get; set; }
        public string? SalaryAmountUser { get;set; }
        public string TaxPercentage { get; set; }
        public string? NetSalary { get;set; }



    }
}
