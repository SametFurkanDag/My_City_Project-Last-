using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        Places GetById(Guid id);
        List<Places> GetAll();
        void Add(Places place);
        void Update(Places place);
        void Delete(Guid id);
        List<Places> GetDeleted();
    }
}