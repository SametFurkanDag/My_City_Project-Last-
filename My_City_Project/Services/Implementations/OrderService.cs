using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public Order GetOrderById(Guid id)
        {
            Log.Information("Sipariş getiriliyor. ID: {OrderId}", id);
            var order = _orderRepository.GetById(id);

            if (order == null)
                Log.Warning("ID {OrderId} ile sipariş bulunamadı.", id);
            else
                Log.Information("ID {OrderId} ile sipariş bulundu.", id);

            return order;
        }

        public List<Order> GetAllOrders()
        {
            Log.Information("Tüm siparişler getiriliyor.");
            var orders = _orderRepository.GetAll();
            Log.Information("{Count} adet sipariş bulundu.", orders.Count);
            return orders;
        }

        public void CreateOrder(Order order)
        {
            try
            {
                _orderRepository.Add(order);
                Log.Information("Yeni sipariş eklendi: {@Order}", order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni sipariş eklenirken hata oluştu: {@Order}", order);
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                var existingOrder = _orderRepository.GetById(order.Id);
                if (existingOrder == null)
                {
                    Log.Warning("ID {OrderId} ile sipariş bulunamadı.", order.Id);
                    throw new Exception("Sipariş bulunamadı.");
                }

                existingOrder.OrderDate = order.OrderDate;
                existingOrder.UserId = order.UserId;
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.OrderItems = order.OrderItems;
                existingOrder.UpdatedDate = DateTime.UtcNow;

                _orderRepository.Update(existingOrder);
                Log.Information("ID {OrderId} ile sipariş güncellendi.", order.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {OrderId} ile sipariş güncellenirken hata oluştu.", order.Id);
                throw;
            }
        }

        public void DeleteOrder(Guid id)
        {
            try
            {
                _orderRepository.Delete(id);
                Log.Information("ID {OrderId} ile sipariş silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {OrderId} ile sipariş silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
