using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
                return NotFound("Sipariş bulunamadı."); 

            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            

            if (order == null || order.OrderItems == null || !order.OrderItems.Any())
            {
                return BadRequest("Sipariş veya sipariş içeriği boş olamaz.");
            }

            try
            {
                
                _orderService.CreateOrder(order, order.OrderItems.ToList());

                
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateOrder(Guid id, [FromBody] Order updatedOrder)
        {
            if (id != updatedOrder.Id)
            {
                return BadRequest("ID uyuşmazlığı.");
            }

            try
            {
                _orderService.UpdateOrder(updatedOrder);
                return Ok(updatedOrder); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                _orderService.DeleteOrder(id);
                return Ok("Sipariş silindi"); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}