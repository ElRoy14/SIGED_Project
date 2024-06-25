using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.Exceptions
{
    public class GetAttendanceException : Exception
    {
        public override string Message { get; }

        public GetAttendanceException() : base()
        {
            Message = "No data found";
        }
    }
}
