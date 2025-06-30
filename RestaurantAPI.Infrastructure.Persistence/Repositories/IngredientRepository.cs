using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Domain.Entities;
using RestaurantAPI.Infrastructure.Persistence.Contexts;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationContext _context;

        public IngredientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
