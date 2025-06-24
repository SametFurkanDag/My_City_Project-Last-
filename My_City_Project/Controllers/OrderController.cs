using Microsoft.AspNetCore.Mvc;
using My_City_Project.Model.Entities;
using My_City_Project.Services.Implementations;
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
        private readonly ICartItemService _cartItemService;

        public OrderController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

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
        public IActionResult Create([FromBody] Order order)
        {
            var cartItems = _cartItemService.GetByUserId(order.UserId);
            if (cartItems == null || !cartItems.Any())
            {
                return BadRequest("Sepet boş, sipariş oluşturulamaz.");
            }
            order.Id = Guid.NewGuid();
            order.CreatedDate = DateTime.Now;
            order.UpdatedDate = DateTime.Now;
            order.IsDeleted = false;
            order.TotalAmount = cartItems.Sum(item => item.Quantity * item.Product.ProductPrice);
            order.OrderItems = new List<OrderItem>();

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.ProductPrice,
                    OrderId = order.Id 
                };

                order.OrderItems.Add(orderItem);
            }

            return Ok(order);
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