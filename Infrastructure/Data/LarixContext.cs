using Domain.Common;
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

        public DbSet<Door> Doors { get; set; }
        public DbSet<GlassType> GlassTypes { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
                //((AuditableEntity)entityEntry.Entity).LastModifiedBy = _userService.GetUser();

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                    //((AuditableEntity)entityEntry.Entity).CreateBy = _userService.GetUser();   // literówka do poprawy
                }
            }
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Door>()
                .HasOne(w => w.GlassType)
                .WithMany(gt => gt.Doors)
                .HasForeignKey(w => w.GlassTypeId); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
