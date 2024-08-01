using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("OrderDetails")]
    public class OrderDetails : BaseModel
    {
        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; } = 0;

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
