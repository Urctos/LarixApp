using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Hinges")]
    public class Hinges : AuditableEntity
    {
        [Key]
        public int HingesId { get; set; }

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
