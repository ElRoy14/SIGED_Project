using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Tax.Exceptions
{
    public class GetTaxesFailedException : Exception
    {
        public override string Message { get; }

        public GetTaxesFailedException() : base()
        {
            Message = "No Taxes found";
        }

    }

}
