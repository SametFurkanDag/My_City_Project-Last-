using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog; 
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class ResellerService : IResellerService
    {
        private readonly IResellerRepository _resellerRepository;
        private readonly ApplicationContext _context;

        public ResellerService(IResellerRepository resellerRepository, ApplicationContext context)
        {
            _resellerRepository = resellerRepository;
            _context = context;
        }

        public Reseller GetResellerById(Guid id)
        {
            Log.Information("Bayi getiriliyor. ID: {ResellerId}", id);
            var reseller = _resellerRepository.GetById(id);

            if (reseller == null)
            {
                Log.Warning("ID {ResellerId} ile bayi bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {ResellerId} ile bayi bulundu.", id);
            }

            return reseller;
        }

        public List<Reseller> GetAllResellers()
        {
            Log.Information("Tüm bayiler getiriliyor.");
            var resellers = _resellerRepository.GetAll();
            Log.Information("{Count} adet bayi bulundu.", resellers.Count);
            return resellers;
        }

        public void CreateReseller(Reseller reseller)
        {
            try
            {
                _resellerRepository.Add(reseller);
                _context.SaveChanges();

                Log.Information("Yeni bayi eklendi: {@Reseller}", reseller);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni bayi eklenirken hata oluştu: {@Reseller}", reseller);
                throw;
            }
        }

        public void UpdateReseller(Reseller reseller)
        {
            try
            {
                _resellerRepository.Update(reseller);
                _context.SaveChanges();

                Log.Information("Bayi güncellendi: {@Reseller}", reseller);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Bayi güncellenirken hata oluştu: {@Reseller}", reseller);
                throw;
            }
        }

        public void DeleteReseller(Guid id)
        {
            try
            {
                _resellerRepository.Delete(id);
                _context.SaveChanges();

                Log.Information("ID {ResellerId} ile bayi silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {ResellerId} ile bayi silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
