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
            return _context.Vendors.ToList();
        }

        public Vendor GetById(Guid id)
        {
            return _context.Vendors.Find(id);
        }

        public void Update(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var vendor = _context.Vendors.Find(id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }
    }
}