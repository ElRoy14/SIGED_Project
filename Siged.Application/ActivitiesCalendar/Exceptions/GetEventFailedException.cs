using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ActivitiesCalendar.Exceptions
{
    public class GetEventFailedException : Exception
    {
        public override string Message { get; }

        public GetEventFailedException() : base() 
        {
            Message = "Data Not Found";
        }
    }
}
