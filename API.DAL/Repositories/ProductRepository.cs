using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;
using API.Domain.Models.DTOs.Product;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class ProductRepository(ApplicationDbContext db) : BaseRepository<Product>(db), IProductRepository
    {
        public async Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDTO productDTO)
        {
            var existingProduct = await dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
                return null;

            existingProduct.Name = productDTO.Name;
            existingProduct.Price = productDTO.Price;
            existingProduct.IsSold = productDTO.IsSold;
            existingProduct.City = productDTO.City;
            existingProduct.Description = productDTO.Description;
            existingProduct.ImageUrl = productDTO.ImageUrl;
            existingProduct.SubCategoryId = productDTO.SubCategoryId;

            await SaveAsync();
            return existingProduct;
        }
    }
}
