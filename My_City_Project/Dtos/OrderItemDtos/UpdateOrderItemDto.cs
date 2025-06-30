using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.OrderItemDtos
{
    public class UpdateOrderItemDto
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
