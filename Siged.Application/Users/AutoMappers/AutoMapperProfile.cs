using AutoMapper;
using Siged.Application.Users.DTOs;
using Siged.Domain;

namespace Siged.Application.Users.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserInfo, GetUser>()
                .ForMember(destination =>
                    destination.RolDescription,
                    options => options.MapFrom(origin => origin.Rol.NameRol)
                 )
                .ForMember(destination =>
                    destination.JobTitleDescription,
                    options => options.MapFrom(origin => origin.JobTitle.JobTitleName)
                 )
                .ForMember(destination =>
                    destination.DepartmentDescription,
                    options => options.MapFrom(origin => origin.Department.DepartmentName)
                 )
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<GetUser, UserInfo>()
                .ForMember(destination =>
                    destination.Rol,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.JobTitle,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.Department,
                    options => options.Ignore()
                 )
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
                );

            CreateMap<UserInfo, CreateUser>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<CreateUser, UserInfo>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
                );

            CreateMap<UserInfo, UpdateUser>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == true ? 1 : 0)
                );

            CreateMap<UpdateUser, UserInfo>()
                .ForMember(destination =>
                    destination.IsActive,
                    options => options.MapFrom(origin => origin.IsActive == 1 ? true : false)
                );

        }

    }

}
