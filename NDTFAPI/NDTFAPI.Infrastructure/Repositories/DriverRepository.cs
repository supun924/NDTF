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
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;

        public DriverRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Driver?> GetByIdAsync(int driverId)
        {
            return await _context.Drivers
                .FirstOrDefaultAsync(x => x.DriverId == driverId);
        }

        public async Task<List<Driver>> SearchAsync(string? search, int pageNumber, int pageSize)
        {
            var query = _context.Drivers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.FirstName.Contains(search) ||
                    x.LastName.Contains(search) ||
                    x.LicenseNumber.Contains(search) ||
                    x.NICNumber.Contains(search));
            }

            return await query
                .OrderBy(x => x.FirstName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        public void Update(Driver driver)
        {
            _context.Drivers.Update(driver);
        }

        public void Delete(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }
    }
}
