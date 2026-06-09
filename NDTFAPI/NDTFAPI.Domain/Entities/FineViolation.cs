using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class FineViolation
    {
        public int FineViolationId { get; set; }

        public int FineId { get; set; }

        public int ViolationId { get; set; }

        public decimal Amount { get; set; }

        public Fine Fine { get; set; } = null!;

        public Violation Violation { get; set; } = null!;
    }
}
