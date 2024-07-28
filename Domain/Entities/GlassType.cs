using Domain.Common;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("GlassTypes")]
    public class GlassType : AuditableEntity, IHasName
    {
        [Key]
        public int Id { get; set; }

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
