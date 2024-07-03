using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Customers.Exceptions
{
    public class GetCustomerFailedException : Exception
    {

        public override string Message { get; }

        public GetCustomerFailedException() : base()
        {
            Message = "No Customer found";
        }
    }
}
