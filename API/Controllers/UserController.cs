﻿using API.DAL.Repositories.IRepository;
using API.Domain.DTOs.User;
using API.Infrastructure.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserRepository repository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userDTO.Password = _passwordHasher.Generate(userDTO.Password);

            var user = userDTO.ToUserFromRegisterRequestDTO();
            await _repository.CreateAsync(user);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserResponseDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _repository.GetByEmailAsync(userDTO.Email);

            if (user == null)
            {
                ModelState.AddModelError("Ошибка", "Данная почта не зарегистрирована");
                return BadRequest(ModelState);
            }

            var result = _passwordHasher.Verify(userDTO.Password, user.PasswordHash);

            if (result == false)
            {
                ModelState.AddModelError("Ошибка", "Неверный пароль");
                return BadRequest(ModelState);
            }

            var token = _jwtProvider.GenerateToken(user);
            HttpContext.Response.Cookies.Append("login_info", token);

            return Ok();
        }

        [HttpPut("{id:guid}-{roleId:int}")]
        [Authorize(Policy = "ExtraPermission")]
        public async Task<IActionResult> ChangeRole([FromRoute] Guid id, [FromRoute] int roleId)
        {
            var result = await _repository.ChangeRoleAsync(id, roleId);

            if (result == false)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequestDTO userDTO) //TODO: Отрефакторить этот небезопасный метод (?)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Guid.TryParse(User.Identities.First()?.Claims.First()?.Value, out var userId) == false)
            {
                ModelState.AddModelError("Ошибка", "Не получилось получить id пользователя");
                return BadRequest(ModelState);
            }

            var result = await _repository.UpdateAsync(userId, userDTO);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}
