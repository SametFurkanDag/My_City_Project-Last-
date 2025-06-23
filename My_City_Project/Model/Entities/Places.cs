using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Places
    {
        [Key]
        public Guid PlaceId { get; set; } = Guid.NewGuid();
        public string PlaceName { get; set; }
        public string PlaceLocation { get; set; }

        // İlişki: Bu adres hangi User'a ait?
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}