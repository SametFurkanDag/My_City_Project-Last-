using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Places:BaseModel
    {
        public string PlaceName { get; set; }
        public string PlaceLocation { get; set; }
        public Guid VendorId { get; set; }
    }
}