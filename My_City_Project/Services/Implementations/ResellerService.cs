using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
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
            return _resellerRepository.GetById(id);
        }

        public List<Reseller> GetAllResellers()
        {
            return _resellerRepository.GetAll();
        }

        public void CreateReseller(Reseller reseller)
        {
            _resellerRepository.Add(reseller);
            _context.SaveChanges();
        }

        public void UpdateReseller(Reseller reseller)
        {
            _resellerRepository.Update(reseller);
            _context.SaveChanges();
        }

        public void DeleteReseller(Guid id)
        {
            _resellerRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}