using System.ComponentModel.DataAnnotations;

namespace API.Domain.DTOs.User
{
    public class UpdateUserRequestDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public decimal PhoneNumber { get; set; }
    }
}
