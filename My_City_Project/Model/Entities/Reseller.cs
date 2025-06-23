using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Reseller
    {
        [Key]
        public Guid ResellerId { get; set; } = Guid.NewGuid();
        public string ResellerName { get; set; }
        public string ResellerLocation { get; set; }

        // İlişki: Bu bayi profili hangi User'a ait?
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}