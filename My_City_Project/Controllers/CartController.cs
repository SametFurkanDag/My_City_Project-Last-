using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

    
        [HttpGet]
        public IActionResult GetAllCarts()
        {
           
            var carts = _cartService.GetAllCarts();
            return Ok(carts);
        }

    
        [HttpGet("{id:guid}")]
        public IActionResult GetCartById(Guid id)
        {
            
            var cart = _cartService.GetCartById(id);
            if (cart == null)
                return NotFound("Sepet bulunamadı");

            return Ok(cart);
        }

        [HttpPost]
        public IActionResult CreateCart([FromBody] Cart cart)
        {
            if (cart == null)
                return BadRequest();

        
            _cartService.CreateCart(cart);

            return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, "Sepet oluşturuldu");
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCart(Guid id, [FromBody] Cart cart)
        {
            if (cart == null || id != cart.Id)
                return BadRequest("Geçersiz istek: ID uyuşmazlığı.");

            var existingCart = _cartService.GetCartById(id);
            if (existingCart == null)
                return NotFound("Güncellenecek sepet bulunamadı");

       
            _cartService.UpdateCart(cart);
            return NoContent();
        }

       
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCart(Guid id)
        {
            var existingCart = _cartService.GetCartById(id);
            if (existingCart == null)
                return NotFound("Silinecek sepet bulunamadı");

     
            _cartService.DeleteCart(id);
            return NoContent();
        }
    }
}