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
                Discount = product.Discount,
                HasDiscount = product.HasDiscount,
                IsSold = product.IsSold,
                City = product.City,
                Brand = product.Brand,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId
            };
        }

        public static Product ToProductFromCreateDTO(this CreateProductRequestDTO productDTO)
        {
            return new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Discount = productDTO.Discount,
                HasDiscount = productDTO.HasDiscount,
                City = productDTO.City,
                Brand = productDTO.Brand,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                CategoryId = productDTO.CategoryId,
                SubCategoryId = productDTO.SubCategoryId
            };
        }
    }
}
