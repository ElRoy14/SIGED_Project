using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Suppliers.Exceptions
{
    public  class GetSuppliersFailedException : Exception
    {
        public override string Message { get; }
        public GetSuppliersFailedException() {

            Message = "No Suppliers found";

        }

       
    }
}
