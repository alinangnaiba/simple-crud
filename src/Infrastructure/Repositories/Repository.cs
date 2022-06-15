using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> FindEntitiesByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<T> FindEntityByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
