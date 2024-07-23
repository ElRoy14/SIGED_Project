using AutoMapper;
using Siged.Application.ServiceNames.DTOs;
using Siged.Application.ServiceNames.Exceptions;
using Siged.Application.ServiceNames.Interfaces;
using Siged.Domain;
using Siged.Domain.Interfaces;

namespace Siged.Application.ServiceNames.Services
{
    public class ServiceNamesService : IServiceNamesService
    {

        private readonly IGenericRepository<ServiceName> _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceNamesService(IGenericRepository<ServiceName> serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<List<GetServiceName>> GetAllServiceNamesAsync()
        {
            try
            {
                var service = await _serviceRepository.VerifyDataExistenceAsync();
                return  _mapper.Map<List<GetServiceName>>(service.ToList());
            }
            catch
            {
                throw new GetServiceNameFailedException();
            }

        }

    }

}
