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
    [Table("Woods")]
    public class Wood : AuditableEntity, IHasName
    {
        [Key]
        public int WoodId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Unit {  get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Door> Doors { get; set; }

        public Wood()
        {
            Doors = new HashSet<Door>();
        }
    }
}
