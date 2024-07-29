using System.Linq.Expressions;

namespace API.DAL.Repositories.IRepository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task Add(T entity);
        Task Delete(int? id);
        Task Save();
    }
}
