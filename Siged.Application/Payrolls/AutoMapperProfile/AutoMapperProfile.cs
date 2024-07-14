using AutoMapper;
using Siged.Application.Payrolls.DTOs;
using Siged.Application.Tax.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Payrolls.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() 
       {
            CreateMap<Payroll, GetPayroll>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.SalaryAmountUser, opt => opt.MapFrom(src => src.Tax.Salary.Amount != null ? src.Tax.Salary.Amount.ToString() : "0"))
                .ForMember(dest => dest.TaxPercentage, opt => opt.MapFrom(src => src.Tax.Percentage.PercentageTax != null ? src.Tax.Percentage.PercentageTax.ToString() : "0"))
                .ForMember(dest => dest.NetSalary, opt => opt.MapFrom(src => src.Tax.NetSalary.ToString()));

            CreateMap<GetPayroll, Payroll>()
                .ForMember(destination => destination.User, options => options.Ignore())
                .ForPath(dest => dest.Tax.Salary.Amount, opt => opt.MapFrom(src => decimal.Parse(src.SalaryAmountUser ?? "0")))
                .ForPath(dest => dest.Tax.Percentage.PercentageTax, opt => opt.MapFrom(src => decimal.Parse(src.TaxPercentage ?? "0")))
                .ForPath(dest => dest.Tax.NetSalary, opt => opt.MapFrom(src => decimal.Parse(src.NetSalary ?? "0")));


            CreateMap<CreatePayroll, Payroll>().ReverseMap();
            CreateMap<UpdatePayroll, Payroll>().ReverseMap();


       }

    }

}
