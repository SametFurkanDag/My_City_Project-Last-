using Microsoft.EntityFrameworkCore;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository; 

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public void Add(CartItem cartItem)
        {
            _cartItemRepository.Add(cartItem);
        }


        public List<CartItem> GetByCartId(Guid cartId)
        {
            return _cartItemRepository.GetAll(cartId);
        }
        public CartItem GetById(Guid id)
        {
            return _cartItemRepository.GetById(id);
        }



        public void Update(CartItem cartItem)
        {
            _cartItemRepository.Update(cartItem);
        }

        public void Delete(Guid id)
        {
            _cartItemRepository.Delete(id);
        }
    }
}
