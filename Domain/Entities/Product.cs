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
    [Table("Products")]
    public class Product : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [ForeignKey(nameof(GlassType))]
        public int GlassTypeId { get; set; }
        public GlassType GlassType { get; set; }

        public Product() { }

        public Product(int id, string name, string description, double width, double height, int glassTypeId)
        {
            (Id, Name, Description, Width, Height, GlassTypeId) = (id, name, description, width, height, glassTypeId);
        }
    }
}
