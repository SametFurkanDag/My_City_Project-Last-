using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationContext _context;

        public CartRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public List<Cart> GetAll()
        {
            return _context.Carts.Where(p => !p.IsDeleted).ToList();
        }

        public Cart GetById(Guid id)
        {
            return _context.Carts.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }

        public void Delete(Guid id)
        {
            var cart = _context.Carts.Find(id);
            if (cart != null && !cart.IsDeleted)
            {
                cart.IsDeleted = true;
            }
        }

        public List<Cart> GetDeleted()
        {
            return _context.Carts.Where(p => p.IsDeleted).ToList();
        }
    }
}