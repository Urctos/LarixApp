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
    [Table("Doors")]
    public class Door : AuditableEntity, IHasName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int GlassTypeId { get; set; }

        [ForeignKey("GlassTypeId")]
        public GlassType GlassType { get; set; }

        [Required]
        public int WoodId { get; set; }
        [ForeignKey("WoodId")]
        public Wood Wood { get; set; }

        [Required]
        public int ImpregnationTypeId { get; set; }
        [ForeignKey("ImpregnationTypeId")]
        public ImpregnationType ImpregnationType { get; set; }


        [Required]
        public int HingesId { get; set; }
        [ForeignKey("HingesId")]
        public Hinges Hinges { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



        public Door() { }

        public Door(int id, string name, string description, double width, double height, decimal price, int glassTypeId, int woodId, int impregnationTypeId, int hingesId )
        {
            (Id, Name, Description, Width, Height, Price, GlassTypeId, WoodId, ImpregnationTypeId, HingesId) = (id, name, description, width, height, price, glassTypeId, woodId, impregnationTypeId, hingesId);
        }
    }
}
