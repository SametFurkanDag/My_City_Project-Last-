using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.CartDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCarts()
        {
            var carts = _cartService.GetAllCarts();
            var result = _mapper.Map<List<ResultCartDto>>(carts);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartById(Guid id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null)
                return NotFound();

            var result = _mapper.Map<GetByIdCartDto>(cart);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCart([FromBody] CreateCartDto createCartDto)
        {
            var cart = _mapper.Map<Cart>(createCartDto);
            cart.Id = Guid.NewGuid();

            _cartService.CreateCart(cart);

            var cartDto=_mapper.Map<CreateCartDto>(cart);
            return Ok(cartDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCart(Guid id)
        {
            var cart = _cartService.GetCartById(id);
            if (cart == null)
                return NotFound();

            _cartService.DeleteCart(id);
            return Ok();
        }
    }
}
