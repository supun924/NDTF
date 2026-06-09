using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameAsync(string roleName);
        Task<Role?> GetByIdAsync(int id);
        Task<List<Role>> GetAllAsync();
        Task AddAsync(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
