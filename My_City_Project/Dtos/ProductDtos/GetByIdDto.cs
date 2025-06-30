namespace My_City_Project.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid VendorId { get; set; }
    }
}
