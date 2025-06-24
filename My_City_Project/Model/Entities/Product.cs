using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Product:BaseModel
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid VendorId { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}