namespace API.Domain.Models.DTOs.Product
{
    public class ProductPageResponseDTO : BaseModelResponseDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool HasDiscount { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
    }
}
