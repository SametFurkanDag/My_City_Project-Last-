using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.OrderDtos
{
    public class GetByIdOrderDto
    {
        public Guid UserId { get; set; }
       
        public Guid Id { get; set; }

    }
}
