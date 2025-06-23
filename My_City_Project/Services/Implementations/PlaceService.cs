using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog; 
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
            Log.Information("Mekan getiriliyor. ID: {PlaceId}", id);
            var place = _placeRepository.GetById(id);

            if (place == null)
            {
                Log.Warning("ID {PlaceId} ile mekan bulunamadı.", id);
            }
            else
            {
                Log.Information("ID {PlaceId} ile mekan bulundu.", id);
            }

            return place;
        }

        public List<Places> GetAllPlaces()
        {
            Log.Information("Tüm mekanlar getiriliyor.");
            var places = _placeRepository.GetAll();
            Log.Information("{Count} adet mekan bulundu.", places.Count);
            return places;
        }

        public void CreatePlace(Places place)
        {
            try
            {
                _placeRepository.Add(place);
                _context.SaveChanges();

                Log.Information("Yeni mekan eklendi: {@Place}", place);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Yeni mekan eklenirken hata oluştu: {@Place}", place);
                throw;
            }
        }

        public void UpdatePlace(Places place)
        {
            try
            {
                _placeRepository.Update(place);
                _context.SaveChanges();

                Log.Information("Mekan güncellendi: {@Place}", place);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Mekan güncellenirken hata oluştu: {@Place}", place);
                throw;
            }
        }

        public void DeletePlace(Guid id)
        {
            try
            {
                _placeRepository.Delete(id);
                _context.SaveChanges();

                Log.Information("ID {PlaceId} ile mekan silindi.", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ID {PlaceId} ile mekan silinirken hata oluştu.", id);
                throw;
            }
        }
    }
}
