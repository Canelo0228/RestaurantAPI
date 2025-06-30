using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        private readonly ApplicationContext _context;
        public DishRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<Dish> GetByIdWithIncludesAsync(int id, List<string> properties)
        {
            IQueryable<Dish> query = _context.Set<Dish>();

            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
