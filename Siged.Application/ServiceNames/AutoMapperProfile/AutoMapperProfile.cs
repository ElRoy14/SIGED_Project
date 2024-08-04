using AutoMapper;
using Siged.Application.ServiceNames.DTOs;
using Siged.Domain;

namespace Siged.Application.ServiceNames.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() 
        { 
            CreateMap<GetServiceName, ServiceName>().ReverseMap();
        }

    }

}
