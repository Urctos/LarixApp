using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public GlassType GlassType { get; set; }
        //public List<OrderItem> OrderItems { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product() { }

        public Product(int id, string name, string description, double width, double height, GlassType glassType)
        {
            (Id, Name, Description, Width, Height, GlassType) = (id, name, description, width, height, glassType);
            CreatedDate = DateTime.UtcNow;
            //OrderItems = new List<OrderItem>();

        }
    }

    public enum GlassType
    {
        SinglePane,
        DoublePane,
        TriplePane
    }
}
