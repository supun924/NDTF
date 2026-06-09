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
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetByNameAsync(string roleName)
            => await _context.Roles
                .FirstOrDefaultAsync(x => x.RoleName == roleName);

        public async Task<Role?> GetByIdAsync(int id)
            => await _context.Roles.FindAsync(id);

        public async Task<List<Role>> GetAllAsync()
            => await _context.Roles.ToListAsync();

        public async Task AddAsync(Role role)
            => await _context.Roles.AddAsync(role);

        public void Update(Role role)
            => _context.Roles.Update(role);

        public void Delete(Role role)
            => _context.Roles.Remove(role);
    }
}
