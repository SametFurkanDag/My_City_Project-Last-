using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Guid CartId { get; set; }

    }
}
