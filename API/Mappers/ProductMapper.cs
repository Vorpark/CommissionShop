using API.Domain.Models;
using API.Domain.Models.DTOs.Product;

namespace API.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponseDTO ToProductResponseDTO(this Product product)
        {
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                IsSold = product.IsSold,
                Price = product.Price,
                HasDiscount = product.HasDiscount,
                DiscountPrice = product.DiscountPrice,
                DiscountPercent = product.DiscountPercent,
                CityId = product.CityId,
                Brand = product.Brand,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId
            };
        }

        public static ProductPageResponseDTO ToProductPageResponseDTO(this Product product)
        {
            return new ProductPageResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                HasDiscount = product.HasDiscount,
                DiscountPrice = product.DiscountPrice,
                DiscountPercent = product.DiscountPercent,
                CityId = product.CityId,
                ImageUrl = product.ImageUrl,
            };
        }

        public static Product ToProductFromCreateRequestDTO(this CreateProductRequestDTO productDTO)
        {
            return new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                HasDiscount = productDTO.HasDiscount,
                DiscountPrice = productDTO.DiscountPrice,
                DiscountPercent = productDTO.DiscountPercent,
                CityId = productDTO.CityId,
                Brand = productDTO.Brand,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                CategoryId = productDTO.CategoryId,
                SubCategoryId = productDTO.SubCategoryId
            };
        }
    }
}
