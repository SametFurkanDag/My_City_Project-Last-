using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(Guid id);
        List<Product> GetAllProducts();
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}