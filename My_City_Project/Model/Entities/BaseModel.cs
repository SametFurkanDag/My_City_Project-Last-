using System.ComponentModel.DataAnnotations;

namespace My_City_Project.Model.Entities
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}