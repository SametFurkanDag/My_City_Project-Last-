using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.Where(p => !p.IsDeleted).ToList();
        }

        public Order GetById(Guid id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Delete(Guid id)
        {
            var order = _context.Orders.Find(id);
            if (order != null && !order.IsDeleted)
            {
                order.IsDeleted = true;
            }
        }

        public List<Order> GetDeleted()
        {
            return _context.Orders.Where(p => p.IsDeleted).ToList();
        }

    }
}