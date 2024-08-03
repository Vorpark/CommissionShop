using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Products")]
    public class Product : BaseModel<Guid>
    {
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; } = 0;
        public bool HasDiscount { get; set; } = false;
        public bool IsSold { get; set; } = false;
        public string City { get; set; } = string.Empty; //TODO: В отдельную модель
        public string Brand {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        public OrderDetails? OrderDetails { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
