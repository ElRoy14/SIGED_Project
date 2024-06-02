using AutoMapper;
using Siged.Application.Authentication.DTOs;
using Siged.Domain.Entities;

namespace Siged.Application.Authentication.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserInfo, LoginRequest>().ReverseMap();

            CreateMap<UserInfo, LoginResponse>()
                .ForMember(destino =>
                    destino.RolDescription,
                    options => options.MapFrom(origen => origen.Rol.NameRol)
                );

            CreateMap<UserInfo, LoginRequest>().ReverseMap();
        }

    }

}
