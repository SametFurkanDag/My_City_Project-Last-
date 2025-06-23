using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Report:BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

      
        public Guid VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
    }
}