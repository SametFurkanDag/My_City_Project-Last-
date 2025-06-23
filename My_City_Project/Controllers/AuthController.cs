using Microsoft.AspNetCore.Mvc;
using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Services;
using System;
using System.Linq;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly TokenService _tokenService;

        public AuthController(ApplicationContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
                return BadRequest("Bu kullanıcı adı zaten kayıtlı.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                PasswordHash = PasswordHelper.HashPassword(request.Password),
                Role = request.Role ?? "User"  
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Kullanıcı başarıyla kayıt oldu.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (user == null)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre");

            bool validPassword = PasswordHelper.VerifyPassword(request.Password, user.PasswordHash);
            if (!validPassword)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre");

            var token = _tokenService.CreateToken(user.Username, user.Role);
            return Ok(new { token });
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }  
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
