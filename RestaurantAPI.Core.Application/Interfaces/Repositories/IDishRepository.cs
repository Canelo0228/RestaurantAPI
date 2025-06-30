using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IDishRepository : IGenericRepository<Dish>
    {
        Task<Dish> GetByIdWithIncludesAsync(int id, List<string> properties);
    }
}
