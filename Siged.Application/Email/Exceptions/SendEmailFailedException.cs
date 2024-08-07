using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Email.Exceptions
{
    public class SendEmailFailedException : Exception
    {
        public override string Message { get; }

        public SendEmailFailedException() : base()
        {
            Message = "Could Not Send Mail";
        }

    }
}
