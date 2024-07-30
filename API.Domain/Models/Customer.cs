using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    public class Customer : BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,0)")]
        public decimal PhoneNumber { get; set; } = 0;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;


        public int CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
