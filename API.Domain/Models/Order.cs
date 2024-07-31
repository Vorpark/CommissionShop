﻿namespace API.Domain.Models
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; } = [];
    }
}
