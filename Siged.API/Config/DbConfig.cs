using Microsoft.EntityFrameworkCore;
using Siged.Infrastructure.Context;

namespace Siged.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<DbSigedContext>(options => options.UseSqlServer(connectionString));

            return service;
        }

    }

}
