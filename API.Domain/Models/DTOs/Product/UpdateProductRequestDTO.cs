using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models.DTOs.Product
{
    public class UpdateProductRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsSold { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public bool HasDiscount { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid SubCategoryId { get; set; }
    }
}
