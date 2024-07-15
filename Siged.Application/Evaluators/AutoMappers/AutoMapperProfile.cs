using AutoMapper;
using Siged.Application.Evaluators.DTOs;
using Siged.Domain;

namespace Siged.Application.Evaluators.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Evaluator, GetEvaluators>()
                .ForMember(destination =>
                    destination.UserName,
                    options => options.MapFrom(origin => origin.User.FullName)
                );

            CreateMap<GetEvaluators, Evaluator>()
                .ForMember(destination =>
                    destination.User,
                    options => options.Ignore()
                );

        }

    }

}
