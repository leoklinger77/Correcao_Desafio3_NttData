using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NttDataSupplier.WebApp.Data;

namespace NttDataSupplier.WebApp.Configuration
{
    public static class IdentityMyConfiguration
    {
        public static void IdentityMyConfig(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
