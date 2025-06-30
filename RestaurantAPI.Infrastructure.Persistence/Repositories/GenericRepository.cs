using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            Entity entry = await _context.Set<Entity>().FindAsync(id);
            _context.Entry(entry).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _context.Set<Entity>().FindAsync(id);
        }
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }
        public virtual async Task<List<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter)
        {
            if (filter != null)
            {
                return await _context.Set<Entity>().Where(filter).ToListAsync();
            }
            else
            {
                return await GetAllAsync();
            }
        }
        public virtual async Task<List<Entity>> GetAllWithIncludesAsync(List<string> properties)
        {
            IQueryable<Entity> query = _context.Set<Entity>().AsQueryable();

            foreach(var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }
    }
}
