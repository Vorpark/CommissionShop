using API.Domain.Models;
using API.Domain.Models.DTOs.Product;
using API.Domain.QueryObjects;

namespace API.DAL.Repositories.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDTO productDTO);
        Task<IEnumerable<Product>> GetPageByQueryAsync(ProductQueryObject query);
    }
}
