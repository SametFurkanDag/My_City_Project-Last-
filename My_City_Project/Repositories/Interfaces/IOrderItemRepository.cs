using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem GetById(Guid id);
        List<OrderItem> GetAll();
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(Guid id);
    }
}