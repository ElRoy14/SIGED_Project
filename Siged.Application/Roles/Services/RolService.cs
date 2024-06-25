using AutoMapper;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Exceptions;
using Siged.Application.Roles.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.Roles.Services
{
    public class RolService : IRolService
    {
        public readonly IGenericRepository<Rol> _rolRepository;
        public readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<GetRol>> GetAllRolesAsync()
        {
            try
            {
                var rol = await _rolRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetRol>>(rol.ToList());

            }
            catch
            {
                throw new GetRolFailedException();
            }

        }

    }

}
