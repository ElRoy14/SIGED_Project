using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class DeleteTaskFailedException : Exception
    {
        public override string Message { get; }

        public DeleteTaskFailedException() : base() 
        {
            Message = "Task Could Not Be Deleted.";
        }
    }
}
