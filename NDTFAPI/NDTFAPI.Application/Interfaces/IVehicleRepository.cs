using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetByIdAsync(int vehicleId);

        Task<List<Vehicle>> SearchAsync(string? search, int pageNumber, int pageSize);

        Task AddAsync(Vehicle vehicle);

        void Update(Vehicle vehicle);

        void Delete(Vehicle vehicle);
    }
}
