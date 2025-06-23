using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationContext _context;

        public ReportRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public List<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public Report GetById(Guid id)
        {
            return _context.Reports.Find(id);
        }

        public void Update(Report report)
        {
            _context.Reports.Update(report);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var report = _context.Reports.Find(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                _context.SaveChanges();
            }
        }
    }
}