using Microsoft.EntityFrameworkCore;
using NDTFAPI.Application.Features.Fines.DTOs;
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
    public class FineRepository : IFineRepository
    {
        private readonly AppDbContext _context;

        public FineRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fine?> GetByIdAsync(int id)
        {
            return await _context.Fines
                .FirstOrDefaultAsync(x => x.FineId == id);
        }

        public async Task<Fine?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Vehicle)
                .Include(x => x.Officer)
                .Include(x => x.FineViolations)
                    .ThenInclude(x => x.Violation)
                .FirstOrDefaultAsync(x => x.FineId == id);
        }

        public async Task<List<Fine>> GetAllAsync()
        {
            return await _context.Fines
                .OrderByDescending(x => x.IssueDate)
                .ToListAsync();
        }

        public async Task<List<Fine>> SearchAsync(
            string? search,
            int pageNumber,
            int pageSize)
        {
            var query = _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Vehicle)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.FineReference.Contains(search) ||
                    x.Driver.FirstName.Contains(search) ||
                    x.Driver.LastName.Contains(search) ||
                    x.Vehicle.RegistrationNumber.Contains(search));
            }

            return await query
                .OrderByDescending(x => x.IssueDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync(string? search)
        {
            var query = _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Vehicle)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.FineReference.Contains(search) ||
                    x.Driver.FirstName.Contains(search) ||
                    x.Driver.LastName.Contains(search) ||
                    x.Vehicle.RegistrationNumber.Contains(search));
            }

            return await query.CountAsync();
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            return new DashboardStatsDto
            {
                TotalFines =
                    await _context.Fines.CountAsync(),

                PendingFines =
                    await _context.Fines
                        .CountAsync(x => x.Status == "PENDING"),

                PaidFines =
                    await _context.Fines
                        .CountAsync(x => x.Status == "PAID"),

                TotalRevenue =
                    await _context.Payments
                        .SumAsync(x => (decimal?)x.Amount) ?? 0,

                TotalDrivers =
                    await _context.Drivers.CountAsync(),

                TotalVehicles =
                    await _context.Vehicles.CountAsync()
            };
        }

        public async Task AddAsync(Fine fine)
        {
            await _context.Fines.AddAsync(fine);
        }

        public void Update(Fine fine)
        {
            _context.Fines.Update(fine);
        }

        public void Delete(Fine fine)
        {
            _context.Fines.Remove(fine);
        }
    }
}
