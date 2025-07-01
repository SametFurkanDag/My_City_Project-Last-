using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public Guid? CartId { get; set; }
    }
}
