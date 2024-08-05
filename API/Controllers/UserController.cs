using API.DAL.Repositories.IRepository;
using API.Domain.Models.DTOs.User;
using API.Infrastructure.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserRepository repository, IPasswordHasher passwordHasher) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        [HttpGet]
        public async Task<IActionResult> Login([FromBody] LoginUserResponseDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _repository.GetByEmailAsync(userDTO.Email);

            if (user == null)
                return NotFound(userDTO.Email);

            var result = _passwordHasher.Verify(userDTO.Password, user.PasswordHash);

            if (result == false)
                return BadRequest(userDTO.Password);

            return Ok("");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userDTO.Password = _passwordHasher.Generate(userDTO.Password);

            var user = userDTO.ToUserFromRegisterRequestDTO();
            await _repository.CreateAsync(user);

            return Ok();
        }
    }
}
