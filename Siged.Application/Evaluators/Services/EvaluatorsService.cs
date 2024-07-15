using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Evaluators.DTOs;
using Siged.Application.Evaluators.Exceptions;
using Siged.Application.Evaluators.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.Evaluators.Services
{
    public class EvaluatorsService : IEvaluatorsService
    {
        private readonly IGenericRepository<Evaluator> _evaluatorsRepository;
        private readonly IMapper _mapper;

        public EvaluatorsService(IGenericRepository<Evaluator> evaluatorsRepository, IMapper mapper)
        {
            _evaluatorsRepository = evaluatorsRepository;
            _mapper = mapper;
        }

        public async Task<List<GetEvaluators>> GetEvaluatorsAsync()
        {
            try
            {
                var evaluators = await _evaluatorsRepository.VerifyDataExistenceAsync();
                var listEvaluators = evaluators
                    .Include(eva => eva.User).ToList();

                return _mapper.Map<List<GetEvaluators>>(listEvaluators);
            }
            catch
            {
                throw new GetEvaluatorFailedException();
            }

        }

    }

}
