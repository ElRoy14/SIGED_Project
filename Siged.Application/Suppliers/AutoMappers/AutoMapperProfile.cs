using AutoMapper;
using Siged.Application.Customers.DTOs;
using Siged.Application.Suppliers.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Suppliers.AutoMappers
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {



                CreateMap<Supplier, GetSuppliers>().ReverseMap();
                CreateMap<Supplier, CreateSuppliers>().ReverseMap();
                CreateMap<Supplier, UpdateSuppliers>().ReverseMap();

         

        }
    }
}
