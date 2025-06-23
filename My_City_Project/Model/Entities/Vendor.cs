using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Vendor:BaseModel
    {
        public string VendorName { get; set; }

        
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        
        public virtual ICollection<Product> Products { get; set; } 
        public virtual ICollection<Report> Reports { get; set; }
    }
}