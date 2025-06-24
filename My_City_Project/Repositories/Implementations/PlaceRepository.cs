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
        }

        public List<Places> GetAll()
        {
            return _context.Places.Where(p => !p.IsDeleted).ToList();
        }
        public Places GetById(Guid id)
        {
            return _context.Places.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }


        public void Update(Places place)
        {
            _context.Places.Update(place);
        }

        public void Delete(Guid id)
        {
            var place = _context.Places.Find(id);
            if (place != null && !place.IsDeleted)
            {
                place.IsDeleted = true;
            }
        }

        public List<Places> GetDeleted()
        {
            return _context.Places.Where(p => p.IsDeleted).ToList();
        }
    }
}