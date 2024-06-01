using AutoMapper;
using Siged.Application.JobTitles.DTOs;
using Siged.Application.JobTitles.Exceptions;
using Siged.Application.JobTitles.Interfaces;
using Siged.Domain.Entities;
using Siged.Domain.Interfaces;

namespace Siged.Application.JobTitles.Services
{
    public class JobTitleService : IJobTitleService
    {
        public readonly IGenericRepository<JobTitle> _jobTitleRepository;
        public readonly IMapper _mapper;

        public JobTitleService(IGenericRepository<JobTitle> jobTitleRepository, IMapper mapper)
        {
            _jobTitleRepository = jobTitleRepository;
            _mapper = mapper;
        }

        public async Task<List<GetJobTitle>> GetAllJobTitleAsync()
        {
            try
            {
                var jobTitles = await _jobTitleRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetJobTitle>>(jobTitles.ToList());

            }
            catch
            {
                throw new GetJobTitleFailedException();
            }

        }

    }
    
}
