using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.CartItemDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;

        public CartItemController(ICartItemService cartItemService, IMapper mapper)
        {
            _cartItemService = cartItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCartItems()
        {
            return Ok("Tüm CartItemları listeleyen metod servis tarafında yok. Gerekirse ekle.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCartItemById(Guid id)
        {
            var cartItem = _cartItemService.GetById(id);
            if (cartItem == null)
                return NotFound();

            var result = _mapper.Map<GetByIdCartItemDto>(cartItem);
            return Ok(result);
        }

        [HttpGet("by-user/{userId}")]
        public IActionResult GetCartItemsByUserId(Guid userId)
        {
            var cartItems = _cartItemService.GetByUserId(userId);
            var result = _mapper.Map<List<ResultCartItemDto>>(cartItems);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCartItem([FromBody] CreateCartItemDto createCartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(createCartItemDto);
            _cartItemService.Add(cartItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] UpdateCartItemDto updateCartItemDto)
        {
            var existingCartItem = _cartItemService.GetById(id);
            if (existingCartItem == null)
                return NotFound();

            _mapper.Map(updateCartItemDto, existingCartItem);
            _cartItemService.Update(existingCartItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(Guid id)
        {
            var existingCartItem = _cartItemService.GetById(id);
            if (existingCartItem == null)
                return NotFound();

            _cartItemService.Delete(id);
            return Ok();
        }
    }
}
