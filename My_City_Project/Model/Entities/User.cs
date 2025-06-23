using System.ComponentModel.DataAnnotations;

namespace My_City_Project.Model.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; } // Not: Gerçek projede bu alan şifrelenmiş (hash) olmalıdır.
        public string Role { get; set; } // "Admin", "Vendor", "Reseller"

        // --- Navigation Properties ---
        public virtual Vendor VendorProfile { get; set; } // User'ın bir Vendor profili olabilir (1-1)
        public virtual Reseller ResellerProfile { get; set; } // User'ın bir Reseller profili olabilir (1-1)
        public virtual Cart Cart { get; set; } // User'ın bir sepeti olabilir (1-1)
        public virtual ICollection<Order> Orders { get; set; } // User'ın birden çok siparişi olabilir (1-N)
        public virtual ICollection<Places> Places { get; set; } // User'ın birden çok adresi olabilir (1-N)
    }
}