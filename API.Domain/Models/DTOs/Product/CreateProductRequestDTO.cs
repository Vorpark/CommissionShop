namespace API.Domain.Models.DTOs.Product
{
    public class CreateProductRequestDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
