using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IReportService
    {
        Report GetReportById(Guid id);
        List<Report> GetAllReports();
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(Guid id);
    }
}