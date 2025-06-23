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
        private readonly ApplicationContext _context; // SaveChanges için

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
            // Burada ürünü eklemeden önce iş kuralları kontrol edilebilir.
            // Örneğin: Aynı isimde başka bir ürün var mı?
            _productRepository.Add(product);
            _context.SaveChanges(); // İşlem tamamlandı, değişiklikleri kaydet.
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.Delete(id); // Bu metodun içinde zaten fiziksel silme yapılıyor.
            _context.SaveChanges();
        }
    }
}