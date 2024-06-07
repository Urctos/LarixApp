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
        public DbSet<Hinges> Hinges { get; set; }
        public DbSet<ImpregnationType> ImpregnationTypes { get; set; }
        public DbSet<Wood> Woods { get; set; }

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

            modelBuilder.Entity<Door>()
                .HasOne(d => d.Wood)
                .WithMany(w => w.Doors)
                .HasForeignKey(d => d.WoodId);

            modelBuilder.Entity<Door>()
                .HasOne(d => d.ImpregnationType)
                .WithMany(it => it.Doors)
                .HasForeignKey(d => d.ImpregnationTypeId);


            modelBuilder.Entity<Door>()
                .HasOne(d => d.Hinges)
                .WithMany(h => h.Doors)
                .HasForeignKey(d => d.HingesId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
