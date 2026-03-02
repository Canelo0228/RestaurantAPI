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

        public async Task<List<Dish>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _context.Set<Dish>().AsQueryable();

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public async Task<List<DishIngredient>> GetDishIngredientsAsync(int id)
        {
            var ingredients = await _context.DishIngredients.Where(a => a.DishId == id).ToListAsync();

            return ingredients;
        }

        public virtual async Task<Dish> GetByIdWithIncludesAsync(int id, List<string> includes)
        {
            IQueryable<Dish> query = _context.Set<Dish>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
