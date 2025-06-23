using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        
        public List<Product> GetAll()
        {
            return _context.Products.Where(p => !p.IsDeleted).ToList();
        }
        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product != null && !product.IsDeleted)
            {
                product.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public List<Product> GetDeleted()
        {
            return _context.Products.Where(p => p.IsDeleted).ToList();
        } 
    }
}
