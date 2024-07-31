using API.Domain.Models;
using API.Domain.Models.DTOs.Product;

namespace API.DAL.Repositories.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDTO productDTO);
    }
}
