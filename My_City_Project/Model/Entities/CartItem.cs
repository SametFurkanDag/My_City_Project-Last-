using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; } = Guid.NewGuid();
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } // Quantity * ProductPrice

        // İlişki: Bu satır hangi sepete ait?
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        // İlişki: Sepete eklenen ürün hangisi?
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}