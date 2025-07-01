using My_City_Project.Model.Entities;
namespace My_City_Project.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string VendorName { get; set; } 
        public DateTime CreatedDate { get; set; }

    }
}
