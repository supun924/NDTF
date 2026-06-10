using Microsoft.EntityFrameworkCore;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Master Tables
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Violation> Violations => Set<Violation>();

        // Transaction Tables
        public DbSet<Fine> Fines => Set<Fine>();
        public DbSet<FineViolation> FineViolations => Set<FineViolation>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<LicenseConfiscation> LicenseConfiscations => Set<LicenseConfiscation>();

        public DbSet<PoliceStation> PoliceStations => Set<PoliceStation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Primary Keys

            modelBuilder.Entity<Role>()
                .HasKey(x => x.RoleId);

            modelBuilder.Entity<User>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.PoliceStation)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PoliceStationId);


            modelBuilder.Entity<Driver>()
                .HasKey(x => x.DriverId);

            modelBuilder.Entity<Vehicle>()
                .HasKey(x => x.VehicleId);

            modelBuilder.Entity<Violation>()
                .HasKey(x => x.ViolationId);

            modelBuilder.Entity<Fine>()
                .HasKey(x => x.FineId);

            modelBuilder.Entity<FineViolation>()
                .HasKey(x => x.FineViolationId);

            modelBuilder.Entity<Payment>()
                .HasKey(x => x.PaymentId);

            modelBuilder.Entity<LicenseConfiscation>()
                .HasKey(x => x.ConfiscationId);

            modelBuilder.Entity<PoliceStation>()
                .HasKey(x => x.StationId);
        }
    }
}
