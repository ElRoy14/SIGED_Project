using AutoMapper;
using Siged.Application.Roles.DTOs;
using Siged.Domain;

namespace Siged.Application.Roles.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rol, GetRol>().ReverseMap();
        }

    }

}
