﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("OrderDetails")]
    public class OrderDetail : BaseModel<Guid>
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
