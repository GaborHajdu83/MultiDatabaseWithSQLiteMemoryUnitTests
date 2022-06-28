using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompanyEmployess.DAL.Repositories
{
    public class RepositoryBase<TContext, T> : IRepositoryBase<T> where T : class where TContext : DbContext
    {
        protected TContext _context;

        public RepositoryBase(TContext context) => _context = context;

        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate);
        public void Add(T entity) => _context.Set<T>().Add(entity);
        public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Remove(T entity) => _context.Set<T>().Remove(entity);
        public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

    }
}
