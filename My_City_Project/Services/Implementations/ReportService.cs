using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ApplicationContext _context;

        public ReportService(IReportRepository reportRepository, ApplicationContext context)
        {
            _reportRepository = reportRepository;
            _context = context;
        }

        public Report GetReportById(Guid id)
        {
            return _reportRepository.GetById(id);
        }

        public List<Report> GetAllReports()
        {
            return _reportRepository.GetAll();
        }

        public void CreateReport(Report report)
        {
            _reportRepository.Add(report);
            _context.SaveChanges();
        }

        public void UpdateReport(Report report)
        {
            _reportRepository.Update(report);
            _context.SaveChanges();
        }

        public void DeleteReport(Guid id)
        {
            _reportRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}