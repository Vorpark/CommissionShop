using API.Domain.Models;
using API.Domain.Models.DTOs.User;

namespace API.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromRegisterRequestDTO(this RegisterUserRequestDTO userDTO)
        {
            return new User()
            {
                Email = userDTO.Email,
                PasswordHash = userDTO.Password
            };
        }
    }
}
