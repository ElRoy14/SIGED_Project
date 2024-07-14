using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.DTOs
{
    public class CreatePayroll
    {
        public int? UserId { get; set; }
        public string? PaymentDate { get; set; }
        public int? TaxId { get; set; }

        public CreatePayroll()
        {
            PaymentDate = "15 y 30";
        }

    }

}
