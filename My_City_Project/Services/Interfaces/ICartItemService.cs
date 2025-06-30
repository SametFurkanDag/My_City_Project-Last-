using System;
using System.Collections.Generic;
using My_City_Project.Model.Entities;
namespace My_City_Project.Services.Interfaces
{
    public interface ICartItemService
    {
        void Add(CartItem cartItem);
        List<CartItem> GetByCartId(Guid cartId);
        CartItem GetById(Guid id);

        void Update(CartItem cartItem);
        void Delete(Guid id);

    }
}
