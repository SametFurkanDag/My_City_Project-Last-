namespace My_City_Project.Dtos.CartItemDtos
{
  
        public class GetByIdCartItemDto
        {
            public Guid Id { get; set; }
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }

    
}
