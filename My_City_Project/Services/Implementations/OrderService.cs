using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ApplicationContext _context;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, ApplicationContext context)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _context = context;
        }

        public Order GetOrderById(Guid id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public void CreateOrder(Order order, List<OrderItem> items)
        {
            _orderRepository.Add(order);
            foreach (var item in items)
            {
                item.OrderId = order.OrderId;
                _orderItemRepository.Add(item);
            }
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Guid id)
        {
            _orderRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}