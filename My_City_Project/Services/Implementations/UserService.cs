using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using My_City_Project.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                Log.Information("Yeni kullanıcı eklendi: {@User}", user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı eklenirken hata oluştu: {@User}", user);
                throw;
            }
        }

        public User GetUserById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void UpdateUser(User user)
        {
            try
            {
                var existingUser = _userRepository.GetById(user.Id);
                if (existingUser == null)
                    throw new Exception("Kullanıcı bulunamadı.");

                existingUser.Username = user.Username;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Role = user.Role;
                existingUser.UpdatedDate = DateTime.UtcNow;

                _userRepository.Update(existingUser);
                Log.Information("Kullanıcı güncellendi: {@User}", existingUser);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı güncellenirken hata oluştu: {@User}", user);
                throw;
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                _userRepository.Delete(id);
                Log.Information("Kullanıcı silindi. Id: {UserId}", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Kullanıcı silinirken hata oluştu. Id: {UserId}", id);
                throw;
            }
        }
    }
}
