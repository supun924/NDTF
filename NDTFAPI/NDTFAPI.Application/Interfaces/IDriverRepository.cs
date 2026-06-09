using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByIdAsync(int driverId);

        Task<List<Driver>> SearchAsync(string? search, int pageNumber, int pageSize);

        Task AddAsync(Driver driver);

        void Update(Driver driver);

        void Delete(Driver driver);
    }
}
