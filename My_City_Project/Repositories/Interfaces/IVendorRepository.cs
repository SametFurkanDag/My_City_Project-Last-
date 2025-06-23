using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IVendorRepository
    {
        Vendor GetById(Guid id);
        List<Vendor> GetAll();
        void Add(Vendor vendor);
        void Update(Vendor vendor);
        void Delete(Guid id);
        List<Vendor> GetDeleted();
    }
}