using System.Linq.Expressions;

namespace API.DAL.Repositories.IRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T?> GetById(Guid id, string? includeProperties = null);
        Task<T?> GetByFilter(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(Guid id);
        Task Save();
    }
}
