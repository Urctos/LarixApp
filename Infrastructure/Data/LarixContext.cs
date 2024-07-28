using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


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

            //var doors = ChangeTracker.Entries<Door>().Select(e => e.Entity).ToList();
            //foreach (var door in doors)
            //{
            //    Console.WriteLine($"Door: {door.Name}, ImpregnationTypeId: {door.ImpregnationTypeId}");
            //}

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

            modelBuilder.Entity<ImpregnationType>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");


            base.OnModelCreating(modelBuilder);
        }
    }
}
