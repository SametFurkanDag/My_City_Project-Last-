using System.ComponentModel.DataAnnotations;

namespace My_City_Project.Model.Entities
{
    public class User:BaseModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } 

        
        public virtual Vendor VendorProfile { get; set; }
        public virtual Reseller ResellerProfile { get; set; } 
        public virtual Cart Cart { get; set; } 
        public virtual ICollection<Order> Orders { get; set; } 
        public virtual ICollection<Places> Places { get; set; } 
    }
}