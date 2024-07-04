using AutoMapper;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TasksEmployee, GetTask>()
                .ForMember(destination =>
                    destination.UserDescription,
                    options => options.MapFrom(origin => origin.User.FullName)
                )
                .ForMember(destination => destination.TaskStatusDescription,
                    options => options.MapFrom(origin => origin.TaskStatus.TaskStatus)
                );

            CreateMap<GetTask, TasksEmployee>()
                .ForMember(destination =>
                    destination.User,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.TaskStatus,
                    options => options.Ignore()
                );
        }
    }
}
