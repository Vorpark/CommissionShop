using API.Domain.Models;
using API.Domain.Models.DTOs.Product;

namespace API.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsSold = product.IsSold,
                City = product.City,
                Description = product.Description,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
