using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models
{
    [Table("Users")]
    public class User : BaseModel<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,0)")]
        public decimal PhoneNumber { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CityId { get; set; }
        public City? City { get; set; }

        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
