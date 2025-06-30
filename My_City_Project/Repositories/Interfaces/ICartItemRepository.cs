using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);
        CartItem GetById(Guid id);
        List<CartItem> GetAll(Guid cartId);
        void Update(CartItem cartItem);
        void Delete(Guid id);
    }
}
