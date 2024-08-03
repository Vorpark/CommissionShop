using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("OrderDetails")]
    public class OrderDetails : BaseGuidModel
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
