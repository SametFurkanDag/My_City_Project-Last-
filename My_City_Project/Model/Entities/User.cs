using System.ComponentModel.DataAnnotations;

namespace My_City_Project.Model.Entities
{
    public class User:BaseModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }  
    }
}