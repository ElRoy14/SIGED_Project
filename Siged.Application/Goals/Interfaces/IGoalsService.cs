using Siged.Application.Goals.DTOs;

namespace Siged.Application.Goals.Interfaces
{
    public interface IGoalsService
    {
        Task<List<GetGoals>> GetAllGoalsAsync();
    }

}
