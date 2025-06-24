using My_City_Project.Model.Entities;
using System;
using System.Collections.Generic;

namespace My_City_Project.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUserById(Guid id);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}
