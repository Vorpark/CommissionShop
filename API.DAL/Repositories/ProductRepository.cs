using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.Models;
using API.Domain.Models.DTOs.Product;
using API.Domain.QueryObjects;
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
            existingProduct.Discount = productDTO.Discount;
            existingProduct.HasDiscount = productDTO.HasDiscount;
            existingProduct.IsSold = productDTO.IsSold;
            existingProduct.City = productDTO.City;
            existingProduct.Brand = productDTO.Brand;
            existingProduct.Description = productDTO.Description;
            existingProduct.ImageUrl = productDTO.ImageUrl;
            existingProduct.SubCategoryId = productDTO.SubCategoryId;

            await SaveAsync();
            return existingProduct;
        }

        public async Task<IEnumerable<Product>?> GetAllByQueryAsync(ProductQueryObject query)
        {
            var products = dbSet.AsNoTracking().AsQueryable().Where(x => x.IsSold == false);

            if (query.CategoryId != null)
                products.Where(x => x.CategoryId == query.CategoryId);
            else if (query.SubCategoryId != null)
                products.Where(x => x.SubCategoryId == query.SubCategoryId);

            if (query.MinPrice != null)
                products = products.Where(x => x.Price >= query.MinPrice);

            if (query.MaxPrice != null)
                products = products.Where(x => x.Price <= query.MaxPrice);

            if (query.HasDiscount != false)
                products = products.Where(x => x.HasDiscount == true);

            if (query.City != null)
                products = products.Where(x => x.City.Contains(query.City)); //TODO: City в отдельную модель

            if (query.Brand != null)
                products = products.Where(x => x.Brand.Contains(query.Brand));

            if (query.SortBy != null)
            {
                if (query.SortBy.Equals("createdAt", StringComparison.OrdinalIgnoreCase))
                    products = query.IsDecsending ? products.OrderByDescending(x => x.CreatedDate) : products.OrderBy(x => x.CreatedDate);
                else if (query.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                    products = query.IsDecsending ? products.OrderByDescending(x => x.Price) : products.OrderBy(x => x.Price);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
    }
}
