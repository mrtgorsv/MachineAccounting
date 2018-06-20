using System.Linq;
using MachineAccounting.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineAccounting.DataContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineType> MachineTypes { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MachineOrder> MachineOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>().ToTable(nameof(Machine));
            modelBuilder.Entity<MachineType>().ToTable(nameof(MachineType));
            modelBuilder.Entity<Storage>().ToTable(nameof(Storage));
            modelBuilder.Entity<Section>().ToTable(nameof(Section));
            modelBuilder.Entity<Order>().ToTable(nameof(Order));
            modelBuilder.Entity<MachineOrder>().ToTable(nameof(MachineOrder));
            base.OnModelCreating(modelBuilder);
        }
    }
}
