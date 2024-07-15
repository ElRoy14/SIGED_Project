using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Exceptions
{
    public class TaskNotCreatedException : Exception
    {
        public override string Message { get; }

        public TaskNotCreatedException() : base()
        {
            Message = "Task Could not be created";
        }
    }
}
