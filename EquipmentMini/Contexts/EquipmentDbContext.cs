using EquipmentMini.Entities;
using Microsoft.EntityFrameworkCore;
using EquipmentMini.Contexts;


namespace EquipmentMini.Contexts
{
    public class EquipmentDbContext : DbContext
    {
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipment => Set<Equipment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InventoryNumber)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(e => e.InventoryNumber).IsUnique();

                entity.Property(e => e.Category)
                    .IsRequired();

                entity.Property(e => e.Room)
                    .IsRequired();

                entity.Property(e => e.Condition)
                    .IsRequired();
            });
        }
    }
}
