namespace API.Domain.Models
{
    public class Cart : BaseModel
    {

        public Customer? Customer { get; set; }

        public ICollection<Product> Products { get; set; } = [];
    }
}
