using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.Services;
using System.Reflection;

namespace RestaurantAPI.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<ITableService, TableService>();
            #endregion
        }
    }
}
