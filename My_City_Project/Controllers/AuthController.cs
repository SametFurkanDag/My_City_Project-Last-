using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
using My_City_Project.Dtos.AuthDtos;
using My_City_Project.Helpers;
using My_City_Project.Model.Entities;
using My_City_Project.Services;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly TokenService _tokenService;
        private readonly IPasswordHelper _passwordHelper;

        public AuthController(ApplicationContext context, TokenService tokenService, IPasswordHelper passwordHelper)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHelper = passwordHelper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == login.Username);
            if (user == null)
                return Unauthorized("Kullanıcı bulunamadı.");

            if (!_passwordHelper.VerifyPassword(login.Password, user.PasswordHash))
                return Unauthorized("Şifre yanlış.");

            var token = _tokenService.CreateToken(user.Username, user.Role);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest("Kullanıcı adı ve şifre gerekli.");

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (existingUser != null)
                return BadRequest("Bu kullanıcı zaten kayıtlı.");

            var hashedPassword = _passwordHelper.HashPassword(dto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                PasswordHash = hashedPassword,
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Kayıt başarılı.");
        }
    }
}
