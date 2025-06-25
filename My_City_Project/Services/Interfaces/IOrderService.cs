using  My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;
public interface IOrderService
{
    Order GetOrderById(Guid id);
    List<Order> GetAllOrders();

    void CreateOrder(Order order);
    void UpdateOrder(Order order); 
    void DeleteOrder(Guid id);
}