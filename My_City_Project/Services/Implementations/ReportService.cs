using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;  
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
            Log.Information("Rapor getiriliyor. ID: {ReportId}", id);
            var report = _reportRepository.GetById(id);

            if (report == null)
            {
                Log.Warning("ID {ReportId} ile rapor bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {ReportId} ile rapor bulundu.", id);
            }

            return report;
        }

        public List<Report> GetAllReports()
        {
            Log.Information("Tüm raporlar getiriliyor.");
            var reports = _reportRepository.GetAll();
            Log.Information("{Count} adet rapor bulundu.", reports.Count);
            return reports;
        }

        public void CreateReport(Report report)
        {
            try
            {
                _reportRepository.Add(report);
                _context.SaveChanges();

                Log.Information("Yeni rapor eklendi: {@Report}", report);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni rapor eklenirken hata oluştu: {@Report}", report);
                throw;
            }
        }

        public void UpdateReport(Report report)
        {
            try
            {
                _reportRepository.Update(report);
                _context.SaveChanges();

                Log.Information("Rapor güncellendi: {@Report}", report);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Rapor güncellenirken hata oluştu: {@Report}", report);
                throw;
            }
        }

        public void DeleteReport(Guid id)
        {
            try
            {
                _reportRepository.Delete(id);
                _context.SaveChanges();

                Log.Information("ID {ReportId} ile rapor silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {ReportId} ile rapor silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
