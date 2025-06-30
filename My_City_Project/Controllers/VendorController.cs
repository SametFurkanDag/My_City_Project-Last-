using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.PlacesDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllPlaces()
        {
            var places = _placeService.GetAllPlaces();
            var result = _mapper.Map<List<ResultPlaceDto>>(places);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaceById(Guid id)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null)
                return NotFound();

            var result = _mapper.Map<GetByIdPlaceDto>(place);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePlace([FromBody] CreatePlaceDto createPlaceDto)
        {
            var place = _mapper.Map<Places>(createPlaceDto);
            _placeService.CreatePlace(place);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlace(Guid id, [FromBody] UpdatePlaceDto updatePlaceDto)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null)
                return NotFound();

            _mapper.Map(updatePlaceDto, place);
            _placeService.UpdatePlace(place);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlace(Guid id)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null)
                return NotFound();

            _placeService.DeletePlace(id);
            return Ok();
        }
    }
}
