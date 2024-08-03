using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Carts")]
    public class Cart : BaseGuidModel
    {
        public Customer? Customer { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}
