﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Cities")]
    public class City : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Product> Products { get; set; } = [];
    }
}
