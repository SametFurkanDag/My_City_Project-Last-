using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        List<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(Guid id);
    }
}