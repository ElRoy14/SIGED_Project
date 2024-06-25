using AutoMapper;
using Siged.Application.Salarys.DTOs;
using Siged.Domain;

namespace Siged.Application.Salarys.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Salary, GetSalary>().ReverseMap();
        }

    }

}
