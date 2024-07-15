using Siged.Application.TaskStatusEmployees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskStatusEmployees.Interfaces
{
    public interface ITaskStatusEmployeeService
    {
        Task<List<GetTaskStatusEmployee>> GetAllTaskStatusEmployeeAsync();
    }
}
