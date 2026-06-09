using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Violation : BaseEntity
    {
        public int ViolationId { get; set; }

        public int CategoryId { get; set; }

        public string ViolationCode { get; set; } = string.Empty;

        public string ViolationName { get; set; } = string.Empty;

        public string? LegalSection { get; set; }

        public decimal FineAmount { get; set; }

        public bool IsActive { get; set; }

        public ICollection<FineViolation> FineViolations { get; set; }
            = new List<FineViolation>();
    }
}
