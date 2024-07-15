using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class GetTaskFailedException : Exception
    {
        public override string Message { get; }
        public GetTaskFailedException() : base() 
        {
            Message = "Data Not Found";
        }
    }
}
