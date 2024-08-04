using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Products")]
    public class Product : BaseModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSold { get; set; } = false;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        public bool HasDiscount { get; set; } = false;
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; } = 0;
        public int DiscountPercent { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CityId { get; set; }
        public City? City { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        public OrderDetails? OrderDetails { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
