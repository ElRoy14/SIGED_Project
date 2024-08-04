using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.Generators
{
    public class InvoiceNumberGenerator
    {
        private static int _lastNumber = 0;

        public static string GetNextInvoiceNumber()
        {
            _lastNumber++;
            return _lastNumber.ToString("D9");
        }
    }
}
