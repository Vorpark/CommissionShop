using API.Domain.DTOs.Product;
using API.Domain.Models;

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
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                CityId = product.CityId,
                BrandId = product.BrandId,
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
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                CityId = productDTO.CityId,
                BrandId = productDTO.BrandId,
                CategoryId = productDTO.CategoryId,
                SubCategoryId = productDTO.SubCategoryId
            };
        }
    }
}
