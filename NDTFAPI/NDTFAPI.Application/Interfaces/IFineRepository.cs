using NDTFAPI.Application.Features.Fines.DTOs;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IFineRepository
    {
        Task<Fine?> GetByIdAsync(int id);

        Task<Fine?> GetByIdWithDetailsAsync(int id);

        Task<List<Fine>> GetAllAsync();

        Task<List<Fine>> SearchAsync(
            string? search,
            int pageNumber,
            int pageSize);

        Task<int> CountAsync(string? search);

        Task<DashboardStatsDto> GetDashboardStatsAsync();

        Task AddAsync(Fine fine);

        void Update(Fine fine);

        void Delete(Fine fine);
    }
}
