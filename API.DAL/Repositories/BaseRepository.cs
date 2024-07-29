using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace API.DAL.Repositories
{
    abstract public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
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
            return await query.Where(filter).FirstAsync();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Delete(int? id)
        {
            await dbSet.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
