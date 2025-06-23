using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Report
    {
        [Key]
        public Guid ReportId { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;

        // İlişki: Bu rapor hangi Vendor'a ait?
        public Guid VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
    }
}