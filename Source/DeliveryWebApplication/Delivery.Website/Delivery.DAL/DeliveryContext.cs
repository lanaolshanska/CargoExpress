using Delivery.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DAL
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext() : base()
        {
        }
        public DeliveryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>().ToTable("Warehouse");
            modelBuilder.Entity<Warehouse>().Property(p => p.Id).HasColumnName("WarehouseId");

            modelBuilder.Entity<Cargo>().ToTable("Cargo");
            modelBuilder.Entity<Cargo>().Property(p => p.Id).HasColumnName("CargoId");
            modelBuilder.Entity<Cargo>().HasOne(p => p.Sender).WithMany(t => t.CargosSent).HasForeignKey(m => m.SenderContactId);
            modelBuilder.Entity<Cargo>().HasOne(p => p.Recipient).WithMany(t => t.CargosReceived).HasForeignKey(m => m.RecipientContactId);
            modelBuilder.Entity<Cargo>().HasOne(p => p.Driver);
            modelBuilder.Entity<Cargo>().HasOne(p => p.Route);

            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Contact>().Property(p => p.Id).HasColumnName("ContactId");

            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Driver>().Property(p => p.Id).HasColumnName("DriverId");

            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Route>().Property(t => t.Id).HasColumnName("RouteId");
            modelBuilder.Entity<Route>().HasOne(p => p.DestWarehouse).WithMany(t => t.RouteDestWarehouse).HasForeignKey(m => m.DestinationWarehouseId);
            modelBuilder.Entity<Route>().HasOne(p => p.OrigWarehouse).WithMany(t => t.RouteOrigWarehouse).HasForeignKey(m => m.OriginWarehouseId);

            modelBuilder.Entity<Shipment>().ToTable("Shipment");
            modelBuilder.Entity<Shipment>().Property(p => p.Id).HasColumnName("ShipmentId");

            modelBuilder.Entity<Truck>().ToTable("Truck");
            modelBuilder.Entity<Truck>().Property(p => p.Id).HasColumnName("TruckId");

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("UserId");
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
