using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.DAL.Repositories
{
    abstract public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel<Guid>
    {
        private readonly ApplicationDbContext _db;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split([','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split([','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.Where(filter).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T?> DeleteAsync(Guid id)
        {
            var entity = await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return null;

            dbSet.Remove(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
