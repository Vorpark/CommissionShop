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

        public Guid CartId { get; set; } = Guid.Empty; //Заглушка, добавить в UserController автоматическое создание корзины 
        public Cart? Cart { get; set; }
    }
}
