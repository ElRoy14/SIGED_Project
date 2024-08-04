using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Exceptions
{
    public class GetInvoiceFailedException : Exception
    {
        public override string Message { get; }

        public GetInvoiceFailedException() : base()
        {
            Message = "No invoice found";        
        }

    }

}
