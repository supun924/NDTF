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
    public class FineViolationRepository : IFineViolationRepository
    {
        private readonly AppDbContext _context;

        public FineViolationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FineViolation fineViolation)
        {
            await _context.FineViolations.AddAsync(fineViolation);
        }

        public async Task AddRangeAsync(
            IEnumerable<FineViolation> fineViolations)
        {
            await _context.FineViolations.AddRangeAsync(fineViolations);
        }

        public async Task<FineViolation?> GetByIdAsync(int id)
        {
            return await _context.FineViolations
                .Include(x => x.Violation)
                .Include(x => x.Fine)
                .FirstOrDefaultAsync(x => x.FineViolationId == id);
        }

        public async Task<List<FineViolation>> GetByFineIdAsync(int fineId)
        {
            return await _context.FineViolations
                .Include(x => x.Violation)
                .Where(x => x.FineId == fineId)
                .ToListAsync();
        }

        public void Update(FineViolation fineViolation)
        {
            _context.FineViolations.Update(fineViolation);
        }

        public void Delete(FineViolation fineViolation)
        {
            _context.FineViolations.Remove(fineViolation);
        }
    }
}
