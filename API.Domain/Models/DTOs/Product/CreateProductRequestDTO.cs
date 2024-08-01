using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models.DTOs.Product
{
    public class CreateProductRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public Guid SubCategoryId { get; set; }
    }
}
