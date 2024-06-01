using Microsoft.Extensions.DependencyInjection;
using Siged.Domain.Interfaces;
using Siged.Infrastructure.Repositorys;

namespace Siged.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            return service.
                AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

    }

}
