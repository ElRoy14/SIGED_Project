using AutoMapper;
using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.Users.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ServicePaymentInvoices.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<ServicePaymentInvoice, GetServicePaymentInvoice>()
                .ForMember(destination =>
                    destination.UserDescription,
                    options => options.MapFrom(origin => origin.User.FullName)
                )
                .ForMember(destination =>
                    destination.ServiceDescription,
                    options => options.MapFrom(origin => origin.ServiceName.ServiceName1)
                )
                .ForMember(destination =>
                    destination.PaymentDescription,
                    options => options.MapFrom(origin => origin.PaymentMethod.PaymentMethod1)
                )
                .ForMember(destination =>
                    destination.AppliedDescription,
                    options => options.MapFrom(origin => origin.AppliedTaxes.TaxToApply)
                )
                .ForMember(destination =>
                    destination.DiscountsDescription,
                    options => options.MapFrom(origin => origin.Discounts.ServiceDiscount)
                )
                .ForMember(destination =>
                    destination.PaymentServiceInvoiceStatusDescription,
                    options => options.MapFrom(origin => origin.PaymentServiceInvoiceStatus.ServicePaymentStatus)
                );


            CreateMap<GetServicePaymentInvoice, ServicePaymentInvoice>()
                .ForMember(destination =>
                    destination.User,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.ServiceName,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.PaymentMethod,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.AppliedTaxes,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.Discounts,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.PaymentServiceInvoiceStatus,
                    options => options.Ignore()
                );

            CreateMap<CreateServicePaymentInvoice, ServicePaymentInvoice>().ReverseMap();

        }
    }
}
