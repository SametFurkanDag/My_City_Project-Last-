using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IVendorService
    {
        Vendor GetVendorById(Guid id);
        List<Vendor> GetAllVendors();
        void CreateVendor(Vendor vendor);
        void UpdateVendor(Vendor vendor);
        void DeleteVendor(Guid id);
    }
}