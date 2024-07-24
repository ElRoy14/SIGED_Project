using Siged.Application.TaskEmployees.DTOs;

namespace Siged.Application.TaskEmployees.Interfaces
{
    public interface ITaskEmployeeService
    {
        Task<List<GetTask>> GetAllTaskAsync();
        Task<List<GetTask>> GetAllPendingTaskAsync();
        Task<List<GetTask>> GetAllTaskListDoneAsync();
        Task<List<GetTask>> GetPendingTaskByEmployee(int userId);
        Task<List<GetTask>> GetTaskDoneByEmployee(int userId);
        Task<GetTask> GetTaskById(int id);
        Task<GetTask> CreateTask (CreateTask model);
        Task<bool> UpdateAsync(UpdateTask model);
        Task<bool> UpdateStateAsync(UpdateStateTask model);
        Task<bool> DeleteAsync(int id);

    }

}
