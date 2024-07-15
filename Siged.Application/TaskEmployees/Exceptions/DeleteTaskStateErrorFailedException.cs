using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class DeleteTaskStateErrorFailedException : Exception
    {
        public override string Message { get; }

        public DeleteTaskStateErrorFailedException() : base() 
        {
            Message = "No task found with that ID";
        }

    }
}
