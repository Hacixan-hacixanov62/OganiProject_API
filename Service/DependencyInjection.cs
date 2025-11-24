using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Services.IService;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();


            return services;
        }
    }
}
