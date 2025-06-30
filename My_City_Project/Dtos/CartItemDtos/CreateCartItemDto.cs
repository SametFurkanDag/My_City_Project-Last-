using My_City_Project.Model.Entities;

namespace My_City_Project.Dtos.CartItemDtos
{
    public class CreateCartItemDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
