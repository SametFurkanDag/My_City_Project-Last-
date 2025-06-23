using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ApplicationContext _context; 

        public ProductService(IProductRepository productRepository, ApplicationContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }

        public Product GetProductById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
            _context.SaveChanges(); 
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.Delete(id); 
            _context.SaveChanges();
        }
    }
}