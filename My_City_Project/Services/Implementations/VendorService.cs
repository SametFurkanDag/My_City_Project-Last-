using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;  // <-- ekledik
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ApplicationContext _context;

        public VendorService(IVendorRepository vendorRepository, ApplicationContext context)
        {
            _vendorRepository = vendorRepository;
            _context = context;
        }

        public Vendor GetVendorById(Guid id)
        {
            Log.Information("Satıcı getiriliyor. ID: {VendorId}", id);
            var vendor = _vendorRepository.GetById(id);

            if (vendor == null)
            {
                Log.Warning("ID {VendorId} ile satıcı bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {VendorId} ile satıcı bulundu.", id);
            }

            return vendor;
        }

        public List<Vendor> GetAllVendors()
        {
            Log.Information("Tüm satıcılar getiriliyor.");
            var vendors = _vendorRepository.GetAll();
            Log.Information("{Count} adet satıcı bulundu.", vendors.Count);
            return vendors;
        }

        public void CreateVendor(Vendor vendor)
        {
            try
            {
                _vendorRepository.Add(vendor);

                Log.Information("Yeni satıcı eklendi: {@Vendor}", vendor);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni satıcı eklenirken hata oluştu: {@Vendor}", vendor);
                throw;
            }
        }

        public void UpdateVendor(Vendor vendor)
        {
            try
            {
                _vendorRepository.Update(vendor);

                Log.Information("Satıcı güncellendi: {@Vendor}", vendor);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Satıcı güncellenirken hata oluştu: {@Vendor}", vendor);
                throw;
            }
        }

        public void DeleteVendor(Guid id)
        {
            try
            {
                _vendorRepository.Delete(id);

                Log.Information("ID {VendorId} ile satıcı silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {VendorId} ile satıcı silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
