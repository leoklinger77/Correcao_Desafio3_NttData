using Microsoft.Extensions.DependencyInjection;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Services;
using NttDataSupplier.Infra.Data;
using NttDataSupplier.Infra.Repository;
using NttDataSupplier.WebApp.Extensions;

namespace NttDataSupplier.WebApp.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void InjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<NttDataContext>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<INotificationService, NotificationService>();


            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<Report>();
        }
    }
}
