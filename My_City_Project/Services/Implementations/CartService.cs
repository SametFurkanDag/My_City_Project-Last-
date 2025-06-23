using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Implementations;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ApplicationContext _context;

        public CartService(ICartRepository cartRepository, ApplicationContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }

        public Cart GetCartById(Guid id)
        {   Log.Information("Sepet getiriliyor. ID: {CartId}", id);
            var cart= _cartRepository.GetById(id);
            if (cart == null)
            {
                Log.Warning("ID {CartId} ile sepet bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {CartId} ile sepet bulundu.", id);
            }
            return cart;
        }

        public List<Cart> GetAllCarts()
        {Log.Information("Tüm sepetler getiriliyor.");
            var carts= _cartRepository.GetAll();
            Log.Information("{Count} sepet bulundu.", carts.Count);
            return carts;
        }

        public void CreateCart(Cart cart)
        {
            try
            {
                _cartRepository.Add(cart);
                _context.SaveChanges();
                Log.Information("Yeni sepet oluşturuluyor. Kullanıcı ID: {UserId}", cart.UserId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sepet oluşturulurken hata oluştu.");
                throw;
            }
            
        }

        public void UpdateCart(Cart cart)
        {
            try
            {
                _cartRepository.Update(cart);
                _context.SaveChanges();
                Log.Information("Sepet güncelleniyor. ID: {CartId}", cart.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sepet güncellenirken hata oluştu.");
                throw;
               
        }

        public void DeleteCart(Guid id)
        {
            try
            {
                _cartRepository.Delete(id);
                _context.SaveChanges();
                Log.Information("Sepet siliniyor. ID: {CartId}", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sepet silinirken hata oluştu. ID: {CartId}", id);
                throw;
                
        }
    }
}