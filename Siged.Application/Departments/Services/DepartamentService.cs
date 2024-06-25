using AutoMapper;
using Siged.Application.Departments.DTOs;
using Siged.Application.Departments.Exceptions;
using Siged.Application.Departments.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.Departments.Services
{
    public class DepartamentService : IDepartamentService
    {
        public readonly IGenericRepository<Department> _departmentRepository;
        public readonly IMapper _mapper;

        public DepartamentService(IGenericRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetDepartment>> GetAllDepartmentsAsync()
        {
            try
            {
                var departments = await _departmentRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetDepartment>>(departments.ToList());

            }
            catch
            {
                throw new GetDepartamentFailedException();
            }

        }

    }

}
