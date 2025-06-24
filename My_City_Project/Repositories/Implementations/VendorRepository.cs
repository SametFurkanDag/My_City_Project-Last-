using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ApplicationContext _context;

        public VendorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
        }

        public List<Vendor> GetAll()
        {
            return _context.Vendors.Where(v => !v.IsDeleted).ToList();
        }

        public Vendor GetById(Guid id)
        {
            return _context.Vendors.FirstOrDefault(v => v.Id == id && !v.IsDeleted);
        }

        public void Update(Vendor vendor)
        {
            var existingVendor = _context.Vendors.FirstOrDefault(v => v.Id == vendor.Id && !v.IsDeleted);
            if (existingVendor == null)
                throw new Exception("Güncellenecek satıcı bulunamadı.");
            existingVendor.VendorName = vendor.VendorName;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var vendor = _context.Vendors.Find(id);
            if (vendor != null && !vendor.IsDeleted)
            {
                vendor.IsDeleted = true;

                _context.SaveChanges();
            }
        }
        public List<Vendor> GetDeleted()
        {
            return _context.Vendors.Where(v => v.IsDeleted).ToList();
        }
    }
}