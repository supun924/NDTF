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
    public class ViolationRepository : IViolationRepository
    {
        private readonly AppDbContext _context;

        public ViolationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Violation?> GetByIdAsync(int id)
        {
            return await _context.Violations
                .FirstOrDefaultAsync(v => v.ViolationId == id);
        }

        public async Task<List<Violation>> GetAllAsync()
        {
            return await _context.Violations
                .OrderBy(v => v.ViolationCode)
                .ToListAsync();
        }

        public async Task<List<Violation>> SearchAsync(string? search)
        {
            var query = _context.Violations
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(v =>
                    v.ViolationCode.Contains(search) ||
                    v.ViolationName.Contains(search) ||
                    (v.LegalSection != null &&
                     v.LegalSection.Contains(search)));
            }

            return await query
                .OrderBy(v => v.ViolationCode)
                .ToListAsync();
        }

        public async Task<List<Violation>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Violations
                .Where(v => ids.Contains(v.ViolationId))
                .ToListAsync();
        }

        public async Task AddAsync(Violation violation)
        {
            await _context.Violations.AddAsync(violation);
        }

        public void Update(Violation violation)
        {
            _context.Violations.Update(violation);
        }

        public void Delete(Violation violation)
        {
            _context.Violations.Remove(violation);
        }

        public async Task<bool> ExistsAsync(string violationCode)
        {
            return await _context.Violations
                .AnyAsync(v => v.ViolationCode == violationCode);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Violations.CountAsync();
        }
    }
}
