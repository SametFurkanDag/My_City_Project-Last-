using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.VendorDto;
using My_City_Project.Dtos.VendorDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IMapper _mapper;

        public VendorController(IVendorService vendorService, IMapper mapper)
        {
            _vendorService = vendorService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllVendors()
        {
            var vendors = _vendorService.GetAllVendors();
            var result = _mapper.Map<List<ResultVendorDto>>(vendors);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateVendor([FromBody] CreateVendorDto createVendorDto)
        {
            var vendor = _mapper.Map<Vendor>(createVendorDto);
            vendor.Id = Guid.NewGuid();

            _vendorService.CreateVendor(vendor);

            var vendorDto = _mapper.Map<ResultVendorDto>(vendor);
            return Ok(vendorDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetVendorById(Guid id)
        {
            var vendor = _vendorService.GetVendorById(id);
            if (vendor == null)
                return NotFound();

            var result = _mapper.Map<GetByIdVendorDto>(vendor);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateVendor(Guid id, [FromBody] UpdateVendorDto vendorUpdateDto)
        {

            var vendor = _mapper.Map<Vendor>(vendorUpdateDto);

            _vendorService.UpdateVendor(vendor);

            var vendorDto = _mapper.Map<ResultVendorDto>(vendor);
            return Ok(vendorDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteVendor(Guid id)
        {
            _vendorService.DeleteVendor(id);
            return Ok("Satıcı Silindi");
        }
    }
}
