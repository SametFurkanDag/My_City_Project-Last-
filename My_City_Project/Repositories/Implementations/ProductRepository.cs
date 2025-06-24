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
            if (product.Id == Guid.Empty)
                product.Id = Guid.NewGuid();

            var exists = _context.Products.Any(p => p.Id == product.Id);
            if (exists)
            {
                throw new Exception("Bu Id ile ürün zaten mevcut.");
            }

            product.CreatedDate = DateTime.UtcNow;
            product.UpdatedDate = DateTime.UtcNow;
            product.IsDeleted = false;

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
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id && !p.IsDeleted);
            if (existingProduct == null)
                throw new Exception("Güncellenecek ürün bulunamadı.");

            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductPrice = product.ProductPrice;
            existingProduct.VendorId = product.VendorId;
            existingProduct.UpdatedDate = DateTime.UtcNow;
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
