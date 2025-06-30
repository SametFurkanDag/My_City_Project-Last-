
namespace My_City_Project.Dtos.CartItemDtos
{
    public class ResultCartItemDto
    {
        public Guid CartItemId { get; set; }  
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
