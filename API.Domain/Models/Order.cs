namespace API.Domain.Models
{
    public class Order : BaseModel
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = [];
    }
}
