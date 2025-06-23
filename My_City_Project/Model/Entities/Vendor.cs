using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Vendor
    {
        [Key]
        public Guid VendorId { get; set; } = Guid.NewGuid();
        public string VendorName { get; set; }

        // İlişki: Bu profil hangi User'a ait?
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Navigation Properties
        public virtual ICollection<Product> Products { get; set; } // Bu satıcının ürünleri
        public virtual ICollection<Report> Reports { get; set; } // Bu satıcıya ait raporlar
    }
}