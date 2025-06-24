using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System.Collections.Generic;
using System;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpGet]
        public IActionResult GetAllCartItems([FromQuery] Guid userId)
        {
            var cartItems = _cartItemService.GetByUserId(userId);

            var result = cartItems.Select(ci => new
            {
                ci.Id,
                ci.CreatedDate,
                ci.UpdatedDate,
                ci.IsDeleted,
                ci.CartId,
                ci.ProductId,
                ci.Quantity,
                Product = new
                {
                    ci.Product.ProductName
                }
            }).ToList();

            return Ok(result);
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetCartItemById(Guid userId)
        {
            var cartItem = _cartItemService.GetById(userId);
            if (cartItem == null)
                return NotFound("Sepet öğesi bulunamadı");
            return Ok(cartItem);
        }

        [HttpPost]
        public IActionResult CreateCartItem([FromBody] CartItem cartItem)
        {
            if (cartItem == null)
                return BadRequest("Sepet öğesi verisi boş.");

            _cartItemService.Add(cartItem);

            return CreatedAtAction(nameof(GetCartItemById), new { id = cartItem.Id }, cartItem);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] CartItem cartItem)
        {
            var existingCartItem = _cartItemService.GetById(id);
            if (existingCartItem == null)
                return NotFound("Sepet öğesi bulunamadı");
            if (cartItem.Id != id)
                return BadRequest("Sepet öğesi ID'si rota ID'si ile eşleşmiyor.");
            _cartItemService.Update(cartItem);
            return Ok("Sepet öğesi güncellendi");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCartItem(Guid id)
        {
            var existingCartItem = _cartItemService.GetById(id);
            if (existingCartItem == null)
                return NotFound("Sepet öğesi bulunamadı");
            _cartItemService.Delete(id);
            return Ok("Sepet ögesi Silindi");
        }
    }
    }
