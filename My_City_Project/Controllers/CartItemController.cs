using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.CartItemDtos;
using My_City_Project.Dtos.ReportDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [Authorize]
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

        [HttpGet("by-cart/{cartId}")]
        public IActionResult GetCartItemsByCartId(Guid cartId)
        {
            var cartItems = _cartItemService.GetByCartId(cartId);
           

            var result = _mapper.Map<List<GetByIdCartItemDto>>(cartItems);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateCartItem([FromBody] CreateCartItemDto createCartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(createCartItemDto);
            if (cartItem != null && cartItem.Id == Guid.Empty)
            {
                cartItem.Id = Guid.NewGuid();
            }


            _cartItemService.Add(cartItem);
            var report = _mapper.Map<CartItem>(createCartItemDto);
            return Ok(report);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(Guid id, [FromBody] UpdateCartItemDto updateCartItemDto)
        {
            var existingCartItems = _cartItemService.GetByCartId(id);

            var existingCartItem = existingCartItems[0];

            _mapper.Map(updateCartItemDto, existingCartItem);
            _cartItemService.Update(existingCartItem);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(Guid id)
        {
            var existingCartItem = _cartItemService.GetByCartId(id);  
            if (existingCartItem == null)
                return NotFound();

            _cartItemService.Delete(id);
            return Ok();
        }

    }
}
