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
    }
}
