using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string OrderStatus { get; set; } // "Hazırlanıyor", "Kargoda" vb.

        // İlişki: Bu sipariş hangi User tarafından verildi?
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Navigation Property: Siparişin içindeki ürün kalemleri
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}