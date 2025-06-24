using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(Guid id);
        List<User> GetAll();
        void Update(User user);
        void Delete(Guid id);
    }
}
