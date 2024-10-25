using System.ComponentModel.DataAnnotations;

namespace API.Domain.DTOs.Product
{
    public class UpdateProductRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool HasDiscount { get; set; }
        [Required]
        public decimal DiscountPrice { get; set; }
        [Required]
        public int DiscountPercent { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
    }
}
