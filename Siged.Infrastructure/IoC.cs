using Microsoft.Extensions.DependencyInjection;
using Siged.Application.Attendances;
using Siged.Domain.Interfaces;
using Siged.Infrastructure.Repositorys;

namespace Siged.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            return service
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient(typeof(IAttendanceRepository<>), typeof(AttendanceRepository<>));

        }

    }

}
