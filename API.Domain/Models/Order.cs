using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Orders")]
    public class Order : BaseModel<Guid>
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = [];
    }
}
