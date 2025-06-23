using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart GetById(Guid id);
        List<Cart> GetAll();
        void Add(Cart cart);
        void Update(Cart cart);
        void Delete(Guid id);
        List<Cart> GetDeleted();
    }
}