using AutoMapper;
using Siged.Application.PaymentMethods.DTOs;
using Siged.Domain;

namespace Siged.Application.PaymentMethods.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<GetPaymentMethods, PaymentMethod>().ReverseMap();
        }

    }

}
