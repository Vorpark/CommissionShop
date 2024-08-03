using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("SubCategories")]
    public class SubCategory : BaseIdModel
    {
        public string Name { get; set; } = string.Empty;
        public string TranslitName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}
