using System.Linq.Expressions;

namespace API.DAL.Repositories.IRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T?> GetByIdAsync(Guid id, string? includeProperties = null);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T?> DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
