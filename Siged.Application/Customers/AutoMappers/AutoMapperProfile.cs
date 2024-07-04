using AutoMapper;
using Siged.Application.Customers.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Customers.AutoMappers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() { 

            CreateMap<Customer,GetCustomer>().ReverseMap();
            CreateMap<Customer,CreateCustomer>().ReverseMap();
            CreateMap<Customer,UpdateCustomer>().ReverseMap();
        
        }
    }
}
