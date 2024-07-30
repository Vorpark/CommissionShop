using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        public bool IsSold { get; set; } = false;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        public OrderDetails? Details { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
