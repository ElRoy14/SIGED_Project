using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class GetTaskFailedByUserException : Exception
    {
        public override string Message { get; }

        public GetTaskFailedByUserException() : base()
        {
            Message = "No task found for this user";
        }



    }
}
