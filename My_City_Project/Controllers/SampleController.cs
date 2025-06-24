using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var username = User.Identity.Name ?? "Bilinmeyen";
            return Ok($"Hoş geldin {username}, profil bilgilerin burada.");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-panel")]
        public IActionResult GetAdminPanel()
        {
            return Ok("Bu alan sadece Admin kullanıcılar içindir.");
        }
    }
}
