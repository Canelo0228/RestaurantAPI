using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using System.Linq.Expressions;

namespace RestaurantAPI.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return await _context.Set<T>().Where(filter).ToListAsync();
            }
            else
            {
                return await GetAllAsync();
            }
        }
        public virtual async Task<List<T>> GetAllWithIncludesAsync(List<Expression<Func<T, object>>> includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }
        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(T entity, int id)
        {
            T entry = await _context.Set<T>().FindAsync(id);

            if (entry != null)
            {
                _context.Entry(entry).CurrentValues.SetValues(entity);
                var primaryKey = _context.Model.FindEntityType(typeof(T))
                                        .FindPrimaryKey().Properties
                                        .Select(p => p.Name).FirstOrDefault();
                if (primaryKey != null)
                {
                    _context.Entry(entry).Property(primaryKey).IsModified = false;
                }

            await _context.SaveChangesAsync();
            }
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
