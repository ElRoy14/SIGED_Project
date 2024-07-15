using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.DTOs
{
    public class UpdatePayroll
    {
        public int PayrollId { get; set; }
        public int? TaxId { get; set; }

    }

}
