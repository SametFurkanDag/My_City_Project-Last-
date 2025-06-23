using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ApplicationContext _context;

        public PlaceRepository(ApplicationContext context)
        {
            _context = context;
        }

        // AddPlace -> Add olarak düzeltildi
        public void Add(Places place)
        {
            _context.Places.Add(place);
            _context.SaveChanges();
        }

        // GetAllPlaces -> GetAll olarak düzeltildi
        public List<Places> GetAll()
        {
            return _context.Places.ToList();
        }

        // GetPlaceById -> GetById olarak düzeltildi
        public Places GetById(Guid id)
        {
            return _context.Places.Find(id);
        }

        // UpdatePlace -> Update olarak düzeltildi
        public void Update(Places place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }

        // DeletePlace -> Delete olarak düzeltildi
        public void Delete(Guid id)
        {
            var place = _context.Places.Find(id);
            if (place != null)
            {
                _context.Places.Remove(place);
                _context.SaveChanges();
            }
        }
    }
}