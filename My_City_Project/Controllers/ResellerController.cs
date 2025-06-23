using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Implementations;
using My_City_Project.Services.Interfaces;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    
    public class ResellerController : ControllerBase
    {
        private readonly IResellerService _resellerService;

        public ResellerController(IResellerService resellerService)
        {
            _resellerService = resellerService;
        }

        
        [HttpGet]
        public IActionResult GetAllResellers()
        {
            var resellers = _resellerService.GetAllResellers();
            return Ok(resellers);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetResellerById(Guid id)
        {
            var reseller = _resellerService.GetResellerById(id);
            if (reseller == null)
                return NotFound("Reseller not found");
            return Ok(reseller);
        }

      
        [HttpPost]
        public IActionResult CreateReseller(Reseller reseller)
        {
            _resellerService.CreateReseller(reseller);
            return Ok(reseller);
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateReseller(Guid id, Reseller reseller)
        {
            if (id != reseller.ResellerId)
                return BadRequest("ID mismatch");

            _resellerService.UpdateReseller(reseller);
            
            return Ok(reseller);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteReseller(Guid id)
        {
            var existingReseller = _resellerService.GetResellerById(id);
            if (existingReseller == null)
                return NotFound("Reseller bulunamadı");

            try
            {
                _resellerService.DeleteReseller(id);  
                return Ok("Reseller başarıyla silindi");
            }
            catch (Exception)
            {
                return StatusCode(500, "Reseller silinirken bir hata oluştu");
            }
        }


    }
}
