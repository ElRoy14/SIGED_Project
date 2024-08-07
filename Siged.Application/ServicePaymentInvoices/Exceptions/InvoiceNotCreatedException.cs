using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Exceptions
{
    public class InvoiceNotCreatedException : Exception
    {
        public override string Message { get; }

        public InvoiceNotCreatedException() : base()
        {
            Message = "Invoice could not be created";
        }
    }
}
