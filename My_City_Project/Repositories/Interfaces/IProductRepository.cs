﻿using My_City_Project.Model.Entities;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}