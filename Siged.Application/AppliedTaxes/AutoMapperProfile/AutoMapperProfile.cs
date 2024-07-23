using AutoMapper;
using Siged.Application.AppliedTaxes.DTOs;
using Siged.Domain;

namespace Siged.Application.AppliedTaxes.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<GetAppliedTaxe, AppliedTaxis>().ReverseMap();
        }

    }

}
