using My_City_Project.Data;
using My_City_Project.Model.Entities;
using My_City_Project.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_City_Project.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            if (user.Id == Guid.Empty)
                user.Id = Guid.NewGuid();

            var exists = _context.Users.Any(u => u.Id == user.Id);
            if (exists)
            {
                throw new Exception("Bu Id ile kullanıcı zaten mevcut.");
            }

            user.CreatedDate = DateTime.UtcNow;
            user.UpdatedDate = DateTime.UtcNow;
            user.IsDeleted = false;

            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
        }

        public List<User> GetAll()
        {
            return _context.Users.Where(u => !u.IsDeleted).ToList();
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id && !u.IsDeleted);
            if (existingUser == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            _context.SaveChanges();
        }


        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user != null && !user.IsDeleted)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
            }
        }
        public List<User> GetDeleted()
        {
            return _context.Users.Where(p => p.IsDeleted).ToList();
        }
    }
}
