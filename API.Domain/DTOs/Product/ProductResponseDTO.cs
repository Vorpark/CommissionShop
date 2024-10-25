namespace API.Domain.DTOs.Product
{
    public class ProductResponseDTO : BaseModelResponseDTO
    {
        public string Name { get; set; }
        public bool IsSold { get; set; }
        public decimal Price { get; set; }
        public bool HasDiscount { get; set; }
        public decimal DiscountPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CityId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
