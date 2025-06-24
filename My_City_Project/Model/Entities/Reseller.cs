using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace My_City_Project.Model.Entities
{
    public class Reseller:BaseModel
    {
        public string ResellerName { get; set; }
        public string ResellerLocation { get; set; }

        public Guid UserId { get; set; }
    }
}