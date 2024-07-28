using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Orders")]
    public class Order: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal NetPrice { get; set; }

        public decimal VatRate { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
