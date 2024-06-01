using Siged.Application.Salarys.DTOs;

namespace Siged.Application.Salarys.Interfaces
{
    public interface ISalaryService
    {
        Task<List<GetSalary>> GetAllSalaryAsync();
    }

}
