using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.DTOs
{
    public class UpdateTask
    {
        public int TaskId { get; set; }
        public string NameTask { get; set; }
        public string? DueDate { get; set; }
        public int UserId { get; set; }
    }
}
