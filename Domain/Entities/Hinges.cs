using Domain.Common;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Hinges")]
    public class Hinges : AuditableEntity, IHasName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerDescription { get; set; }

        [Required]
        [MaxLength(100)]
        public string Unit { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Door> Doors { get; set; }

        public Hinges()
        {
            Doors = new HashSet<Door>();
        }
    }
}
