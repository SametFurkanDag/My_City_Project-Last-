﻿using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;  
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
            Log.Information("Ürün getiriliyor. ID: {ProductId}", id);
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                Log.Warning("ID {ProductId} ile ürün bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {ProductId} ile ürün bulundu.", id);
            }

            return product;
        }

        public List<Product> GetAllProducts()
        {
            Log.Information("Tüm ürünler getiriliyor.");
            var products = _productRepository.GetAll();
            Log.Information("{Count} ürün bulundu.", products.Count);
            return products;
        }

        public void CreateProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);

                Log.Information("Yeni ürün eklendi: {@Product}", product);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni ürün eklenirken hata oluştu: {@Product}", product);
                throw;  
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                var existingProduct = _productRepository.GetById(product.Id);
                if (existingProduct == null)
                {
                    Log.Warning("Güncellenmek istenen ürün bulunamadı. ID: {ProductId}", product.Id);
                    throw new Exception("Ürün bulunamadı.");
                }
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.VendorId = product.VendorId;
                existingProduct.UpdatedDate = DateTime.UtcNow;

                _productRepository.Update(existingProduct);

                Log.Information("Ürün başarıyla güncellendi: {@Product}", existingProduct);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ürün güncellenirken hata oluştu: {@Product}", product);
                throw;
            }
        }


        public void DeleteProduct(Guid id)
        {
            try
            {
                _productRepository.Delete(id);

                Log.Information("ID {ProductId} ile ürün silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {ProductId} ile ürün silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
