using  My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;
public interface IOrderService
{
    Order GetOrderById(Guid id);
    List<Order> GetAllOrders();
    // Sadece bu metodun var olduğunu kabul ediyoruz:
    void CreateOrder(Order order, List<OrderItem> items);
    void UpdateOrder(Order order); // Update için bu metodun da olduğunu varsayalım
    void DeleteOrder(Guid id);
}