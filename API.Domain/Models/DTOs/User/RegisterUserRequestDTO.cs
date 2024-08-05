using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models.DTOs.User
{
    public class RegisterUserRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
