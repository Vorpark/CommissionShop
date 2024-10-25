using API.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models.UserModels
{
    [Table("Users")]
    public class User : BaseModel<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,0)")]
        public decimal PhoneNumber { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int RoleId { get; set; } = (int)Roles.Editor; //TODO: Заглушка для проверки работоспособности куки
        public Role? Role { get; set; }

        public Guid CartId { get; set; } = new Guid("dbbb30b9-ee12-41f0-ad68-b049316516a7"); //TODO: Заглушка, добавить в UserController автоматическое создание корзины 
        public Cart? Cart { get; set; }
    }
}
