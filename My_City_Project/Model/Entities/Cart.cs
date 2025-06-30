using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_City_Project.Model.Entities
{
    public class Cart : BaseModel
    {
        public Guid UserId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}