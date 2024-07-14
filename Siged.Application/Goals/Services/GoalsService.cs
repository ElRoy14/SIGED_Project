using AutoMapper;
using Siged.Application.Goals.Interfaces;
using Siged.Domain.Interfaces;
using Siged.Domain;
using Siged.Application.Goals.DTOs;
using Siged.Application.Goals.Exceptions;

namespace Siged.Application.Goals.Services
{
    public class GoalsService : IGoalsService
    {
        public readonly IGenericRepository<Goal> _goalsRepository;
        public readonly IMapper _mapper;

        public GoalsService(IGenericRepository<Goal> goalsRepository, IMapper mapper)
        {
            _goalsRepository = goalsRepository;
            _mapper = mapper;
        }

        public async Task<List<GetGoals>> GetAllGoalsAsync()
        {
            try
            {
                var goals = await _goalsRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetGoals>>(goals.ToList());

            }
            catch
            {
                throw new GetGoalFailedException();
            }

        }

    }

}
