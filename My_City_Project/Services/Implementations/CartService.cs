using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ApplicationContext _context;

        public CartService(ICartRepository cartRepository, ApplicationContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }

        public Cart GetCartById(Guid id)
        {
            return _cartRepository.GetById(id);
        }

        public List<Cart> GetAllCarts()
        {
            return _cartRepository.GetAll();
        }

        public void CreateCart(Cart cart)
        {
            _cartRepository.Add(cart);
            _context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.Update(cart);
            _context.SaveChanges();
        }

        public void DeleteCart(Guid id)
        {
            _cartRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}