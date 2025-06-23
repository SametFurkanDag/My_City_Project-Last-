using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface ICartService
    {
        Cart GetCartById(Guid id);
        List<Cart> GetAllCarts();
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Guid id);
    }
}