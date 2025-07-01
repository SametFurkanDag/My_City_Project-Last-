using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.OrderDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            var result = _mapper.Map<List<ResultOrderDto>>(orders);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{id:guid}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
                return NotFound("Sipariş bulunamadı.");

            var result = _mapper.Map<GetByIdOrderDto>(order);
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            if (order.Id == Guid.Empty)
            {
                order.Id = Guid.NewGuid();
            }
            _orderService.CreateOrder(order);
            return Ok(order);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateOrder(Guid id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            if (id != updateOrderDto.UserId)
            {
                return BadRequest("ID uyuşmazlığı.");
            }

            var order = _orderService.GetOrderById(id);
            if (order == null)
                return NotFound("Sipariş bulunamadı.");

            _mapper.Map(updateOrderDto, order);

                _orderService.UpdateOrder(order);
                return Ok(order);
           
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
                _orderService.DeleteOrder(id);
                return Ok("Sipariş silindi");
            }
        }
    }

