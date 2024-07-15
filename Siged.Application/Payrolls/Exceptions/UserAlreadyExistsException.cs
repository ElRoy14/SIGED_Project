using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public override string Message { get; }

        public UserAlreadyExistsException() : base()
        {
            Message = "El usuario ya tiene un registro de nómina.";
        }
    }
}
