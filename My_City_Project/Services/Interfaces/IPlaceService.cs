using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IPlaceService
    {
        Places GetPlaceById(Guid id);
        List<Places> GetAllPlaces();
        void CreatePlace(Places place);
        void UpdatePlace(Places place);
        void DeletePlace(Guid id);
    }
}