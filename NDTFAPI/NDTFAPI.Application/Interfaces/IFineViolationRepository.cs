using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Interfaces
{
    public interface IFineViolationRepository
    {
        Task AddAsync(FineViolation fineViolation);

        Task AddRangeAsync(IEnumerable<FineViolation> fineViolations);

        Task<List<FineViolation>> GetByFineIdAsync(int fineId);

        Task<FineViolation?> GetByIdAsync(int id);

        void Update(FineViolation fineViolation);

        void Delete(FineViolation fineViolation);
    }
}
