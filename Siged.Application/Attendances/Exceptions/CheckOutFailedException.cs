using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.Exceptions
{
    public class CheckOutFailedException : Exception
    {
        public override string Message { get; }


        public CheckOutFailedException() : base()
        {
            Message = "Could not Check Out";
        }
    }
}
