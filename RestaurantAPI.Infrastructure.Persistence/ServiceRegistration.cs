using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using RestaurantAPI.Infrastructure.Persistence.Repositories;

namespace RestaurantAPI.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ConnectionString"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)                    
                )
            );
            #endregion

            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            #endregion
        }
    }
}
