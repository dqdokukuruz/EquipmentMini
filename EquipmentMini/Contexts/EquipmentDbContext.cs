
using EquipmentMini.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMini.Contexts
{
    public class EquipmentDbContext : DbContext
    {
        public EquipmentDbContext(DbContextOptions<EquipmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Condition> Conditions => Set<Condition>();

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

                entity.HasIndex(e => e.InventoryNumber)
                    .IsUnique();

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Equipment)
                    .HasForeignKey(e => e.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Room)
                    .WithMany(r => r.Equipment)
                    .HasForeignKey(e => e.RoomId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Condition)
                    .WithMany(c => c.Equipment)
                    .HasForeignKey(e => e.ConditionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
