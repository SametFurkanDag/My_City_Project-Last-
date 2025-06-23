using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class CartItem:BaseModel
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; } 

        
        public Guid CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

       
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}