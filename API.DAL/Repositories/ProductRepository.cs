using API.DAL.Data;
using API.DAL.Repositories.IRepository;
using API.Domain.DTOs.Product;
using API.Domain.Models;
using API.Domain.QueryObjects;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class ProductRepository(ApplicationDbContext db) : BaseRepository<Product>(db), IProductRepository
    {
        public async Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDTO productDTO)
        {
            var product = await dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return null;

            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.HasDiscount = productDTO.HasDiscount;
            product.DiscountPrice = productDTO.DiscountPrice;
            product.DiscountPercent = productDTO.DiscountPercent;
            product.Description = productDTO.Description;
            product.ImageUrl = productDTO.ImageUrl;
            product.UpdatedDate = DateTime.UtcNow;
            product.CityId = productDTO.CityId;
            product.BrandId = productDTO.BrandId;
            product.CategoryId = productDTO.CategoryId;
            product.SubCategoryId = productDTO.SubCategoryId;

            await SaveAsync();
            return product;
        }

        public async Task<Product?> UpdateIsSoldAsync(Guid id, bool isSold)
        {
            var product = await dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return null;

            product.IsSold = isSold;

            await SaveAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetPageByQueryAsync(ProductQueryObject query)
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

            if (query.HasDiscount != null)
                products = products.Where(x => x.HasDiscount == query.HasDiscount);

            if (query.CityId != null)
                products = products.Where(x => x.CityId == query.CityId);

            if (query.BrandId != null)
                products = products.Where(x => x.BrandId == query.BrandId);

            if (query.SortBy != null)
            {
                if (query.SortBy.Equals("date", StringComparison.OrdinalIgnoreCase))
                    products = query.IsDecsending ? products.OrderByDescending(x => x.UpdatedDate) : products.OrderBy(x => x.UpdatedDate);
                else if (query.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                    products = query.IsDecsending ? products.OrderByDescending(x => x.Price) : products.OrderBy(x => x.Price);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
    }
}
