using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public override string Message { get; }

        public TaskNotFoundException() : base() 
        {
            Message = "Task Could not be found.";
        }
    }
}
