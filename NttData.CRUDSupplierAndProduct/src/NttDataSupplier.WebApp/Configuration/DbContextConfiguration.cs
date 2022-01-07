using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NttDataSupplier.Infra.Data;
using NttDataSupplier.WebApp.Data;

namespace NttDataSupplier.WebApp.Configuration
{
    public static class DbContextConfiguration
    {
        public static void DbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<NttDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
