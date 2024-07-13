using AutoMapper;
using Siged.Application.Tax.DTOs;
using Siged.Application.Users.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Tax.AutoMappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Taxis, GetTaxes>()
                .ForMember(dest => dest.TaxPercentage, opt => opt.MapFrom(src => src.Percentage.PercentageTax.ToString()))
                .ForMember(dest => dest.SalaryAmount, opt => opt.MapFrom(src => src.Salary.Amount.ToString()));

            CreateMap<GetTaxes, Taxis>()
                .ForMember(destination => destination.Percentage,
                           options => options.Ignore())
                .ForMember(destination => destination.Salary,
                           options => options.Ignore());


        }

    }

}
