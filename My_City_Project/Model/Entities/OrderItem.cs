using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class OrderItem :BaseModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get;  set; }
    }
}