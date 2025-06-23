using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; } = Guid.NewGuid();

        // İlişki: Bu sepet hangi User'a ait?
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Navigation Property: Sepetin içindeki ürün satırları
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}