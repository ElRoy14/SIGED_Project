using Microsoft.EntityFrameworkCore;
using Siged.Domain;

namespace Siged.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            service.AddDbContext<SigedContext>(options => options.UseSqlServer(connectionString));

            return service;
        }

    }

}
