using AutoMapper;
using Siged.Application.TaskStatusEmployees.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskStatusEmployees.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<GetTaskStatusEmployee, TaskStatusEmployee>().ReverseMap();
        }
    }
}
