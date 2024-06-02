using AutoMapper;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Salarys.Exceptions;
using Siged.Application.Salarys.Interfaces;
using Siged.Domain.Entities;
using Siged.Domain.Interfaces;

namespace Siged.Application.Salarys.Services
{
    public class SalaryService : ISalaryService
    {
        public readonly IGenericRepository<Salary> _salaryRepository;
        public readonly IMapper _mapper;

        public SalaryService(IGenericRepository<Salary> salaryRepository, IMapper mapper)
        {
            _salaryRepository = salaryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSalary>> GetAllSalaryAsync()
        {
            try
            {
                var salary = await _salaryRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetSalary>>(salary.ToList());

            }
            catch
            {
                throw new GetSalaryFailedException();
            }

        }

    }

}
