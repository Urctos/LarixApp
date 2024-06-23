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

    [Table("GlassTypes")]
    public class GlassType : AuditableEntity, IHasName
    {
        [Key]
        public int GlassTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }


        public ICollection<Door> Doors { get; set; }

        public GlassType()
        {
            Doors = new HashSet<Door>();
        }
    }
}
