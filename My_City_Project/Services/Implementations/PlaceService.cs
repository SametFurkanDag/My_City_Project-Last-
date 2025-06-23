using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly ApplicationContext _context;

        public PlaceService(IPlaceRepository placeRepository, ApplicationContext context)
        {
            _placeRepository = placeRepository;
            _context = context;
        }

        public Places GetPlaceById(Guid id)
        {
            return _placeRepository.GetById(id);
        }

        public List<Places> GetAllPlaces()
        {
            return _placeRepository.GetAll();
        }

        public void CreatePlace(Places place)
        {
            _placeRepository.Add(place);
            _context.SaveChanges();
        }

        public void UpdatePlace(Places place)
        {
            _placeRepository.Update(place);
            _context.SaveChanges();
        }

        public void DeletePlace(Guid id)
        {
            _placeRepository.Delete(id);
            _context.SaveChanges();
        }
    }
}