﻿using AutoMapper;
using Siged.Application.Departments.DTOs;
using Siged.Domain;

namespace Siged.Application.Departments.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Department, GetDepartment>().ReverseMap();
        }

    }

}
