using Siged.Application.TaskEmployees.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Interfaces
{
    public interface ITaskEmployeeService
    {
        public Task<List<GetTask>> GetTaskByNameAsync(string name);
        public Task<GetTask> GetTaskById(int id);
        Task<List<GetTask>> GetAllTaskAsync();
        Task<GetTask> CreateTask (CreateTask model);
        Task<bool> UpdateAsync(UpdateTask model);
        Task<bool> DeleteAsync(int id);
    }
}
