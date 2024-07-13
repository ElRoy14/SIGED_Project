using Siged.Application.Evaluators.DTOs;

namespace Siged.Application.Evaluators.Interfaces
{
    public interface IEvaluatorsService
    {
        Task<List<GetEvaluators>> GetEvaluatorsAsync();
    }

}
