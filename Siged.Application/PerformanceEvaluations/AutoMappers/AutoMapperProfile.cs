using AutoMapper;
using Siged.Application.PerformanceEvaluations.DTOs;
using Siged.Application.Users.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.PerformanceEvaluations.AutoMappers
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() 
        {
            CreateMap<PerformanceEvaluation, GetPerformanceEvaluation>()
                .ForMember(destination =>
                    destination.EvaluatorName,
                    options => options.MapFrom(origin => origin.Evaluator.User.FullName)
                )
                .ForMember(destination =>
                    destination.GoalName,
                    options => options.MapFrom(origin => origin.Goal.Goal1)
                )
                .ForMember(destination =>
                    destination.GoalValueData,
                    options => options.MapFrom(origin => origin.Goal.GoalValue)
                )
                .ForMember(destination =>
                    destination.UserName,
                    options => options.MapFrom(origin => origin.User.FullName)
                );


            CreateMap<GetPerformanceEvaluation, PerformanceEvaluation>()
                .ForMember(destination =>
                    destination.Evaluator,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.Goal,
                    options => options.Ignore()
                )
                .ForMember(destination =>
                    destination.User,
                    options => options.Ignore()
                );

            CreateMap<CreatePerformanceEvaluation, PerformanceEvaluation>().ReverseMap();
            CreateMap<UpdatePerformanceEvaluation, PerformanceEvaluation>().ReverseMap();
        }

    }
}
