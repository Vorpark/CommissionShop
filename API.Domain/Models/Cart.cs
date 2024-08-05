using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Carts")]
    public class Cart : BaseModel<Guid>
    {
        public User? User { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}
