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

        public void Add(Places place)
        {
            _context.Places.Add(place);
            _context.SaveChanges();
        }

        public List<Places> GetAll()
        {
            return _context.Places.ToList();
        }
        public Places GetById(Guid id)
        {
            return _context.Places.Find(id);
        }

        public void Update(Places place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var place = _context.Places.Find(id);
            if (place != null && !place.IsDeleted)
            {
                place.IsDeleted = true;
                _context.SaveChanges();
            }
        }

        public List<Places> GetDeleted()
        {
            return _context.Places.Where(p => p.IsDeleted).ToList();
        }
    }
}