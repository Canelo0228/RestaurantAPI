using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<Table> GetByIdWithIncludesAsync(int id, List<string> includes);
    }
}
