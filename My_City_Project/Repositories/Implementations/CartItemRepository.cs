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
            if (cartItem.Id == Guid.Empty)
                cartItem.Id = Guid.NewGuid();

            var exists = _context.CartItems.Any(ci => ci.Id == cartItem.Id);
            if (exists)
                throw new Exception("Bu Id ile zaten bir CartItem mevcut.");

            cartItem.CreatedDate = DateTime.UtcNow;
            cartItem.UpdatedDate = DateTime.UtcNow;
            cartItem.IsDeleted = false;

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public CartItem GetById(Guid id)
        {
            return _context.CartItems.FirstOrDefault(ci => ci.Id == id && !ci.IsDeleted);
        }

        public List<CartItem> GetByUserId(Guid userId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == userId && !c.IsDeleted);
            if (cart == null)
                return new List<CartItem>();

            return _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.CartId == cart.Id && !ci.IsDeleted)
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
        }
    }
}