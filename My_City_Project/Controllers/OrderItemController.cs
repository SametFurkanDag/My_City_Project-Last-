using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_City_Project.Dtos.OrderItemDtos;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            var orderItems = _orderItemService.GetAllOrderItems();
            var result = _mapper.Map<List<ResultOrderItemDto>>(orderItems);
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderItemByOrderId(Guid orderId)
        {
            var orderItem = _orderItemService.GetOrderItemById(orderId);
            if (orderItem == null)
                return NotFound();

            var result = _mapper.Map<GetByIdOrderItemDto>(orderItem);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrderItem([FromBody] CreateOrderItemDto createOrderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(createOrderItemDto);
            _orderItemService.CreateOrderItem(orderItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderItem(Guid id, [FromBody] UpdateOrderItemDto updateOrderItemDto)
        {
            var orderItem = _orderItemService.GetOrderItemById(id);
            if (orderItem == null)
                return NotFound();

            _mapper.Map(updateOrderItemDto, orderItem);
            _orderItemService.UpdateOrderItem(orderItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(Guid id)
        {
            var orderItem = _orderItemService.GetOrderItemById(id);
            if (orderItem == null)
                return NotFound();

            _orderItemService.DeleteOrderItem(id);
            return Ok();
        }
    }
}
