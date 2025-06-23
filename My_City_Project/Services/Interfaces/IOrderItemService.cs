using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IOrderItemService
    {
        OrderItem GetOrderItemById(Guid id);
        List<OrderItem> GetAllOrderItems();
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(Guid id);
    }
}