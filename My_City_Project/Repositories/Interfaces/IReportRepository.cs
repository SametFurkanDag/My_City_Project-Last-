using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Report GetById(Guid id);
        List<Report> GetAll();
        void Add(Report report);
        void Update(Report report);
        void Delete(Guid id);
        List<Report> GetDeleted();
    }
}