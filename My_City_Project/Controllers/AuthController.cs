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

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
                return Unauthorized("Geçersiz kullanıcı adı veya şifre");

            var token = _tokenService.CreateToken(user.Username, user.Role);
            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
