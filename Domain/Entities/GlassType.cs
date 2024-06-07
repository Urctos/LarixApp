﻿using Domain.Common;
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
    public class GlassType : AuditableEntity
    {
        [Key]
        public int GlassTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }


        public ICollection<Door> Doors { get; set; }

        public GlassType()
        {
            Doors = new HashSet<Door>();
        }
    }
}
