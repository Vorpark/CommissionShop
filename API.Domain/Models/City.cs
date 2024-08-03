namespace API.Domain.Models
{
    public class City : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = [];
    }
}
