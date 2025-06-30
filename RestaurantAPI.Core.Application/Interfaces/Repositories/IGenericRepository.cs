using System.Linq.Expressions;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity, int id);
        Task DeleteAsync(Entity entity);
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task<List<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter);
        Task<List<Entity>> GetAllWithIncludesAsync(List<string> properties);
    }
}
