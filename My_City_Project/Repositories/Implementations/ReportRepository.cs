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
        }

        public List<Report> GetAll()
        {
            return _context.Reports.Where(p => !p.IsDeleted).ToList();
        }

        public Report GetById(Guid id)
        {
            return _context.Reports.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void Update(Report report)
        {
            _context.Reports.Update(report);
        }

        public void Delete(Guid id)
        {
            var report = _context.Reports.Find(id);
            if (report != null && !report.IsDeleted)
            {
                report.IsDeleted = true;
            }
        }

        public List<Report> GetDeleted()
        {
            return _context.Reports.Where(p => p.IsDeleted).ToList();
        }

    }
}