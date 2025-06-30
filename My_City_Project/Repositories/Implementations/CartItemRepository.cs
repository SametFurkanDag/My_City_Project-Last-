using Microsoft.EntityFrameworkCore;
using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ApplicationContext _context;

        public CartItemRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }
        public CartItem GetById(Guid id)
        {
            return _context.CartItems.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public List<CartItem> GetAll(Guid cartId)
        {
            return _context.CartItems
                .Where(p => p.CartId == cartId && !p.IsDeleted)
                .ToList();
        }


        public void Update(CartItem cartItem)
        {
            var existing = _context.CartItems.FirstOrDefault(ci => ci.Id == cartItem.Id && !ci.IsDeleted);
            if (existing == null)
                throw new Exception("CartItem bulunamadı.");

            existing.Quantity = cartItem.Quantity;
            existing.UpdatedDate = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cartItem = _context.CartItems.FirstOrDefault(ci => ci.Id == id && !ci.IsDeleted);
            if (cartItem == null)
                throw new Exception("CartItem bulunamadı.");

            cartItem.IsDeleted = true;
            cartItem.UpdatedDate = DateTime.UtcNow;

            _context.SaveChanges();
        }

    }
}