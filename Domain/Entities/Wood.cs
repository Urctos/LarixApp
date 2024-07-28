using Domain.Common;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Woods")]
    public class Wood : AuditableEntity, IHasName
    {
        [Key]
        public int Id { get; set; }

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
