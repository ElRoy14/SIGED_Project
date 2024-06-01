using Siged.Application.Departments.DTOs;

namespace Siged.Application.Departments.Interfaces
{
    public interface IDepartamentService
    {
        Task<List<GetDepartment>> GetAllDepartmentsAsync();
    }

}
