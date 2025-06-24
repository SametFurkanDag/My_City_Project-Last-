using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class ResellerRepository : IResellerRepository
    {
        private readonly ApplicationContext _context;

        public ResellerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Reseller reseller)
        {
            _context.Resellers.Add(reseller);
        }

        public List<Reseller> GetAll()
        {
            return _context.Resellers.Where(p => !p.IsDeleted).ToList();
        }

        public Reseller GetById(Guid id)
        {
            return _context.Resellers.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Reseller reseller)
        {
            _context.Resellers.Update(reseller);
        }

        public void Delete(Guid id)
        {
            var reseller = _context.Resellers.Find(id);
            if (reseller != null && !reseller.IsDeleted)
            {
                reseller.IsDeleted = true;
            }
        }

        public List<Reseller> GetDeleted()
        {
            return _context.Resellers.Where(p => p.IsDeleted).ToList();
        }

    }
}