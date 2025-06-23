using My_City_Project.Data;
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
        private readonly ApplicationContext _context;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, ApplicationContext context)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _context = context;
        }

        public Order GetOrderById(Guid id)
        {
            Log.Information("Sipariş getiriliyor. ID: {OrderId}", id);
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                Log.Warning("ID {OrderId} ile sipariş bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {OrderId} ile sipariş bulundu.", id);
            }

            return order;
        }

        public List<Order> GetAllOrders()
        {
            Log.Information("Tüm siparişler getiriliyor.");
            var orders = _orderRepository.GetAll();
            Log.Information("{Count} adet sipariş bulundu.", orders.Count);
            return orders;
        }

        public void CreateOrder(Order order, List<OrderItem> items)
        {
            try
            {
                _orderRepository.Add(order);
                foreach (var item in items)
                {
                    item.OrderId = order.Id;
                    _orderItemRepository.Add(item);
                }
                _context.SaveChanges();

                Log.Information("Yeni sipariş oluşturuldu: {@Order} ve {ItemCount} adet sipariş kalemi eklendi.", order, items.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni sipariş oluşturulurken hata oluştu: {@Order}", order);
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                _orderRepository.Update(order);
                _context.SaveChanges();

                Log.Information("Sipariş güncellendi: {@Order}", order);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Sipariş güncellenirken hata oluştu: {@Order}", order);
                throw;
            }
        }

        public void DeleteOrder(Guid id)
        {
            try
            {
                _orderRepository.Delete(id);
                _context.SaveChanges();

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
