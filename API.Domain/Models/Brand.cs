using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Brands")]
    public class Brand : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = [];
    }
}
