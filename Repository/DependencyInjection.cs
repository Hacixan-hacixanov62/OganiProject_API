
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.IRepositories;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepositroy>();
            services.AddScoped<IProductRepository, ProductRepository>();


            return services;
        }
    }
}
