using AutoMapper;
using Siged.Application.Attendances.DTOs;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Attendance, CreateCheckIn>().ReverseMap();
            CreateMap<Attendance, CheckOut>().ReverseMap();

            CreateMap<Attendance, GetAttendance>()
                .ForMember(destination =>
                    destination.UserDescription,
                    options => options.MapFrom(origin => origin.User.FullName));

            CreateMap<GetAttendance, Attendance>()
                .ForMember(destination =>
                    destination.User,
                    options => options.MapFrom(origin => origin.User.FullName));

        }

    }
}
