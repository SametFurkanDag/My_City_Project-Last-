using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.PlacesDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPlaces()
        {
            var places = _placeService.GetAllPlaces();
            var placeDtos = _mapper.Map<List<ResultPlaceDto>>(places);
            return Ok(placeDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaceById(Guid id)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null)
                return NotFound("Mekan Bulunamadı");

            var placeDto = _mapper.Map<ResultPlaceDto>(place);
            return Ok(placeDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePlace([FromBody] CreatePlaceDto placeDto)
        {
            var place = _mapper.Map<Places>(placeDto);
            place.Id = Guid.NewGuid();
            _placeService.CreatePlace(place);
            var resultDto = _mapper.Map<ResultPlaceDto>(place);
            return Ok(resultDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdatePlace(Guid id, [FromBody] UpdatePlaceDto placeDto)
        {
            var place = _mapper.Map<Places>(placeDto);
            _placeService.UpdatePlace(place);
            var resultDto = _mapper.Map<ResultPlaceDto>(place);
            return Ok(resultDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePlace(Guid id)
        {
            _placeService.DeletePlace(id);
            return Ok("Mekan Silindi");
        }
    }
}
