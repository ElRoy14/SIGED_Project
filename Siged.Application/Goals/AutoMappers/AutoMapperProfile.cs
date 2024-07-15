using AutoMapper;
using Siged.Application.Goals.DTOs;
using Siged.Domain;

namespace Siged.Application.Goals.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<GetGoals, Goal>().ReverseMap();
        }

    }

}
