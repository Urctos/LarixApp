using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class LarixContext : DbContext
    {
        public LarixContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Window> Windows { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Window>()
                .HasOne(w => w.GlassType)
                .WithMany(gt => gt.Windows)
                .HasForeignKey(w => w.GlassTypeId); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
