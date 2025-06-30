using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.CartDtos
{
    public class GetByIdCartDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
