using API.Domain.DTOs.Product;
using API.Domain.Models;
using API.Domain.QueryObjects;

namespace API.DAL.Repositories.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> UpdateAsync(Guid productId, UpdateProductRequestDTO productDTO);
        Task<Product?> UpdateIsSoldAsync(Guid productId, bool isSold);
        Task<IEnumerable<Product>> GetPageByQueryAsync(ProductQueryObject query);
    }
}
