using AutoMapper;
using Siged.Application.Menus.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Menus.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Menu, GetMenu>()
                .ForMember(destination =>
                destination.SubMenus,
                opt => opt.MapFrom(origen => origen.InverseParentMenu)
                );
        }
    }
}
