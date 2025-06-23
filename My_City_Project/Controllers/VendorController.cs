using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public IActionResult GetAllVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorById(Guid id)
        {
            var vendor = _vendorService.GetVendorById(id);
            if (vendor == null)
                return NotFound("Vendor not found");
            return Ok(vendor);
        }

        [HttpPost]
        public IActionResult CreateVendor(Vendor vendor)
        {
            _vendorService.CreateVendor(vendor);
            return CreatedAtAction(nameof(GetVendorById), new { id = vendor.VendorId }, vendor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVendor(Vendor vendor)
        {
            _vendorService.UpdateVendor(vendor);
            return Ok(vendor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVendor(Guid id)
        {
            _vendorService.DeleteVendor(id);
            return Ok("Vendor deleted successfully");
        }
    }
}
