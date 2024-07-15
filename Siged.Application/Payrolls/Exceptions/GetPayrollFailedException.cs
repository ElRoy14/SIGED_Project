using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.Exceptions
{
    public class GetPayrollFailedException : Exception
    {
        public override string Message { get; }

        public GetPayrollFailedException() : base()
        {
            Message = "No Payroll found";
        }
    }
}
