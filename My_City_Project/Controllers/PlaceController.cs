using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public IActionResult GetAllPlaces()
        {
            var places = _placeService.GetAllPlaces();
            return Ok(places);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaceById(Guid id)
        {
            var place = _placeService.GetPlaceById(id);
            if (place == null)
                return NotFound("Mekan Bulunamadı");
            return Ok(place);
        }
        [HttpPost]
        public IActionResult CreatePlace([FromBody] Places place)
        {
            if (place == null)
                return BadRequest("Place bilgisi boş olamaz.");

            if (place.Id == Guid.Empty)
                place.Id = Guid.NewGuid();

            _placeService.CreatePlace(place);

            return Ok(place);
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePlace(Guid id, Places place)
        {
            if (id != place.Id)
                return BadRequest("ID eşleşmedi");

            _placeService.UpdatePlace(place);
            return Ok(place);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlace(Guid id)
        {
            _placeService.DeletePlace(id);
            return Ok("Mekan Silindi");
        }
    }
}
