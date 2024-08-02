namespace API.Domain.Models.DTOs.Product
{
    public class ProductDTO : BaseModelDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool HasDiscount { get; set; }
        public bool IsSold { get; set; }
        public string City { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
