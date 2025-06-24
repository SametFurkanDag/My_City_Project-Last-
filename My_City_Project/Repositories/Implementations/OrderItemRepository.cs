using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationContext _context;

        public OrderItemRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public List<OrderItem> GetAll()
        {
            return _context.OrderItems.Where(p => !p.IsDeleted).ToList();
        }

        public OrderItem GetById(Guid id)
        {
            return _context.OrderItems.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public void Delete(Guid id)
        {
            var orderitem = _context.OrderItems.Find(id);
            if (orderitem != null && !orderitem.IsDeleted)
            {
                orderitem.IsDeleted = true;
            }
        }

        public List<OrderItem> GetDeleted()
        {
            return _context.OrderItems.Where(p => p.IsDeleted).ToList();
        }
    }
}