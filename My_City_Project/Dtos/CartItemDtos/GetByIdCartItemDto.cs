namespace My_City_Project.Dtos.CartItemDtos
{
  
        public class GetByIdCartItemDto
        {
            public Guid CartItemId { get; set; }
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }

    
}
