using Microsoft.Extensions.DependencyInjection;
using Siged.Application.Attendances;
using Siged.Application.Attendances.Interfaces;
using Siged.Application.Authentication.Interfaces;
using Siged.Application.Authentication.Services;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Customers.Servicices;
using Siged.Application.Departments.Interfaces;
using Siged.Application.Departments.Services;
using Siged.Application.JobTitles.Interfaces;
using Siged.Application.JobTitles.Services;
using Siged.Application.Menus.Interfaces;
using Siged.Application.Menus.Services;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Roles.Services;
using Siged.Application.Salarys.Interfaces;
using Siged.Application.Salarys.Services;
using Siged.Application.Suppliers.Interfaces;
using Siged.Application.Suppliers.Services;
using Siged.Application.Users.Interfaces;
using Siged.Application.Users.Services;

namespace Siged.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service
                .AddScoped<IRolService, RolService>()
                .AddScoped<IDepartamentService, DepartamentService>()
                .AddScoped<IJobTitleService, JobTitleService>()
                .AddScoped<ISalaryService, SalaryService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAttendanceService, AttendanceService>()
                .AddScoped<IMenuService, MenuService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ISupplierService, SupplierService>();



        }

    }

}
