using AutoMapper;
using Siged.Application.JobTitles.DTOs;
using Siged.Domain;

namespace Siged.Application.JobTitles.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<JobTitle, GetJobTitle>().ReverseMap();
        }

    }

}
