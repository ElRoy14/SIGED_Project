using AutoMapper;
using Siged.Application.DiscountsService.DTOs;
using Siged.Domain;

namespace Siged.Application.DiscountsService.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<GetDiscount, Discount>().ReverseMap();
        }

    }

}
