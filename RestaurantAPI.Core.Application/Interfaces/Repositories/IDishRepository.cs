using RestaurantAPI.Core.Domain.Entities;
using System.Linq.Expressions;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        Task<Dish> GetByIdWithIncludesAsync(int id, List<string> includes);
        Task<List<Dish>> GetAllWithIncludeAsync(List<string> propierties);
        Task<List<DishIngredient>> GetDishIngredientsAsync(int id);
    }
}
