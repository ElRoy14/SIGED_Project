using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.DTOs
{
    public class CreateTask
    {
        public string? NameTask { get; set; }
        public string? DueDate { get; set; }
        public int UserId {  get; set; }

    }
}
