using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IResellerRepository
    {
        Reseller GetById(Guid id);
        List<Reseller> GetAll();
        void Add(Reseller reseller);
        void Update(Reseller reseller);
        void Delete(Guid id);
        List<Reseller> GetDeleted();
    }
}