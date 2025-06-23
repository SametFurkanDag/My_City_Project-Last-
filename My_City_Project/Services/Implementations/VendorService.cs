using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
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
            return _vendorRepository.GetById(id);
        }

        public List<Vendor> GetAllVendors()
        {
            return _vendorRepository.GetAll();
        }

        public void CreateVendor(Vendor vendor)
        {
            _vendorRepository.Add(vendor);
            _context.SaveChanges();
        }

        public void UpdateVendor(Vendor vendor)
        {
            _vendorRepository.Update(vendor);
            _context.SaveChanges();
        }

        public void DeleteVendor(Guid id)
        {
            _vendorRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}