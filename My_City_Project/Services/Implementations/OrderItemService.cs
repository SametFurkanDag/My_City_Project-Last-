using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OrderItem GetOrderItemById(Guid id)
        {
            return _orderItemRepository.GetById(id);
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _orderItemRepository.GetAll();
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.Update(orderItem);
        }

        public void DeleteOrderItem(Guid id)
        {
            _orderItemRepository.Delete(id);
        }
    }
}