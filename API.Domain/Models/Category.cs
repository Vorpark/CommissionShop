using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Categories")]
    public class Category : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string TranslitName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<SubCategory> SubCategories { get; set; } = [];
    }
}
