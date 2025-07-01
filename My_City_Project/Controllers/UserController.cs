using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound("Kullanıcı bulunamadı");

            return Ok(user);
        }

        [HttpPost] 
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest("Kullanıcı verisi boş.");

            if (string.IsNullOrWhiteSpace(user.Username))
                return BadRequest("Username boş olamaz.");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                return BadRequest("PasswordHash boş olamaz.");

            _userService.CreateUser(user);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
                return BadRequest("ID uyuşmazlığı veya veri eksik.");

            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
                return NotFound("Kullanıcı bulunamadı");

            _userService.UpdateUser(user);
            return Ok("Kullanıcı güncellendi.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
                return NotFound("Kullanıcı bulunamadı");

            _userService.DeleteUser(id);
            return Ok("Kullanıcı silindi.");
        }
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
            return Ok(new { UserId = userId });
        }

    }
}