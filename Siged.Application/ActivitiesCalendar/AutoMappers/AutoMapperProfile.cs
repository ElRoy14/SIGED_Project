﻿using AutoMapper;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Domain;
using Siged.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ActivitiesCalendar.AutoMappers
{
    public class AutoMapperProfile  : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetTask, Event>()
                .ForMember(dest =>
                dest.Title,
                opt => opt.MapFrom(src => $"{src.UserDescription}: {src.NameTask}"))
                .ForMember(dest => 
                dest.Start,
                opt => opt.MapFrom(src => src.StartDate.ToString()))
                .ForMember(dest => 
                dest.End,
                opt => opt.MapFrom(src => src.DueDate));

            CreateMap<Event, GetTask>()
                .ForMember(dest => 
                dest.NameTask,
                opt => opt.Ignore())
                .ForMember(dest =>
                dest.StartDate,
                opt => opt.Ignore())
                .ForMember(dest =>
                dest.DueDate,
                opt => opt.Ignore());

        }
    }
}
