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
            if (order.Id == Guid.Empty)
                order.Id = Guid.NewGuid();
            var exists = _context.Orders.Any(p => p.Id == order.Id);
            if (exists)
            {
                throw new Exception("Bu Id ile sipariş zaten mevcut.");
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            var orders = _context.Orders.Where(p => !p.IsDeleted).ToList();

            foreach (var order in orders)
            {
                order.OrderItems = _context.OrderItems
                    .Where(oi => oi.OrderId == order.Id)
                    .ToList();

                foreach (var item in order.OrderItems)
                {
                    item.Product = _context.Products
                        .FirstOrDefault(p => p.Id == item.ProductId);
                }
            }

            return orders;
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