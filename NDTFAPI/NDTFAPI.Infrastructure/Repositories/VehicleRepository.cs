using Microsoft.EntityFrameworkCore;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using NDTFAPI.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetByIdAsync(int vehicleId)
        {
            return await _context.Vehicles
                .Include(x => x.Driver)
                .FirstOrDefaultAsync(x => x.VehicleId == vehicleId);
        }

        public async Task<List<Vehicle>> SearchAsync(string? search, int pageNumber, int pageSize)
        {
            var query = _context.Vehicles
                .Include(x => x.Driver)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.RegistrationNumber.Contains(search) ||
                    x.Brand.Contains(search) ||
                    x.Model.Contains(search) ||
                    x.Color.Contains(search));
            }

            return await query
                .OrderBy(x => x.RegistrationNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }
    }
}
