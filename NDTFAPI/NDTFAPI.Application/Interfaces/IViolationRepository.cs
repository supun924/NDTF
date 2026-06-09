using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IViolationRepository
    {
        Task<Violation?> GetByIdAsync(int id);

        Task<List<Violation>> GetAllAsync();

        Task<List<Violation>> SearchAsync(string? search);

        Task<List<Violation>> GetByIdsAsync(List<int> ids);

        Task AddAsync(Violation violation);

        void Update(Violation violation);

        void Delete(Violation violation);

        Task<bool> ExistsAsync(string violationCode);

        Task<int> CountAsync();
    }
}
