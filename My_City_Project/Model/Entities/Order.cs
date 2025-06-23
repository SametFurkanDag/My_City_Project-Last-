using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Order:BaseModel
    {
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string OrderStatus { get; set; } 

      
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}