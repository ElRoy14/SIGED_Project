using Siged.Application.Customers.DTOs;
using Siged.Application.PerformanceEvaluations.DTOs;
using Siged.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.Interfaces
{
    public interface IPerformanceEvaluationService
    {
        Task<List<GetPerformanceEvaluation>> GetAllPerformanceAsycn();
        Task<GetPerformanceEvaluation> Register(CreatePerformanceEvaluation model);
        Task<bool> UpdateAsync(UpdatePerformanceEvaluation model);
        Task<bool> DeleteAsync(int id);

        Task<GetPerformanceEvaluation> GetPerformanceById(int id);
    }
}
