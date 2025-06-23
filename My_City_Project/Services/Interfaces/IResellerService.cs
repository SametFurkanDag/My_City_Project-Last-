using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IResellerService
    {
        Reseller GetResellerById(Guid id);
        List<Reseller> GetAllResellers();
        void CreateReseller(Reseller reseller);
        void UpdateReseller(Reseller reseller);
        void DeleteReseller(Guid id);
    }
}