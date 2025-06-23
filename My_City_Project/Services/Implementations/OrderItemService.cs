using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using Serilog;
namespace My_City_Project.Services.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OrderItem GetOrderItemById(Guid id)
        {
            Log.Information("Sipariş öğesi getiriliyor. ID: {OrderItemId}", id);
            var orderıtem = _orderItemRepository.GetById(id);
            if(orderıtem==null){
                Log.Information("ID {OrderItemId} ile sipariş öğesi bulundu.", id);

            }
            else
            {
                Log.Warning("ID {OrderItemId} ile sipariş öğesi bulunamadı.", id);

            }
            return orderıtem; 
        }


        public List<OrderItem> GetAllOrderItems()
        {Log.Information("Tüm sipariş öğeleri getiriliyor.");
            var orderitem= _orderItemRepository.GetAll();
            Log.Information("{Count} sipariş öğesi bulundu.", orderitem.Count);
            return orderitem;
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            try
            {
                _orderItemRepository.Add(orderItem);

                Log.Information("Yeni sipariş öğesi ekleniyor: {@OrderItem}", orderItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni sipariş öğesi eklenirken hata oluştu: {@OrderItem}", orderItem);
                throw;

            }
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                _orderItemRepository.Update(orderItem);
                Log.Information("Sipariş öğesi güncelleniyor: {@OrderItem}", orderItem);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sipariş öğesi güncellenirken hata oluştu: {@OrderItem}", orderItem);
                throw;

            }
        }

        public void DeleteOrderItem(Guid id)
        {
            try
            {
                _orderItemRepository.Delete(id);
                Log.Information("Sipariş öğesi silindi. ID: {OrderItemId}", id);  
            }
            catch
            {
                Log.Error("Sipariş öğesi silinirken hata oluştu. ID: {OrderItemId}", id);
                throw;
            }
            
        }
    }
}