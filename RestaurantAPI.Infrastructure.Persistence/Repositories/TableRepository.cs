using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationContext _context;
        public TableRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<Table> GetByIdWithIncludesAsync(int id, List<string> includes)
        {
            IQueryable<Table> query = _context.Set<Table>().AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
