using AutoMapper;
using Siged.Application.PaymenInvoiceStatus.DTOs;
using Siged.Domain;

namespace Siged.Application.PaymenInvoiceStatus.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<GetPaymentServiceInvoiceStatus, PaymentServiceInvoiceStatus>().ReverseMap();
        }

    }

}
