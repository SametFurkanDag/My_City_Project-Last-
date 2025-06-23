using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Interfaces;
using System.Collections.Generic;

namespace My_City_Project.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            var orderItems = _orderItemService.GetAllOrderItems();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItemById(Guid id)
        {
            var item = _orderItemService.GetOrderItemById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateOrderItem(OrderItem item)
        {
            try
            {
                _orderItemService.CreateOrderItem(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOrderItem(OrderItem updatedItem)
        {
            try
            {
                _orderItemService.UpdateOrderItem(updatedItem);
                return Ok(updatedItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(Guid id)
        {
            try
            {
                _orderItemService.DeleteOrderItem(id);
                return Ok("Sipariş öğesi silindi");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
