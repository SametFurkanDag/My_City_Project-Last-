using System;
using System.Collections.Generic;
using My_City_Project.Model.Entities;
namespace My_City_Project.Services.Interfaces
{
    public interface ICartItemService
    {
        void Add(CartItem cartItem);
        CartItem GetById(Guid id);
        List<CartItem> GetByUserId(Guid userId);

        void Update(CartItem cartItem);
        void Delete(Guid id);

    }
}
