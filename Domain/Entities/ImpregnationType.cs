using Domain.Common;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("ImpregnationTypes")]
    public class ImpregnationType : AuditableEntity, IHasName
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
        public string Unit { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Door> Doors { get; set; }

        public ImpregnationType()
        {
            Doors = new HashSet<Door>();
        }

    }
}
