using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskStatusEmployees.Exceptions
{
    public class GetTaskStatusEmployeeFailedException : Exception
    {
        public override string Message { get; }

        public GetTaskStatusEmployeeFailedException() : base()
        {
            Message = "No status found";
        }

    }

}
