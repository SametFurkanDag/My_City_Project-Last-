namespace My_City_Project.Dtos.OrderItemDtos
{
    public class CreateOrderItemDto
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
