using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Fine : BaseEntity
    {
        public int FineId { get; set; }

        public string FineReference { get; set; } = string.Empty;

        public int OfficerId { get; set; }

        public int DriverId { get; set; }

        public int VehicleId { get; set; }

        public int StationId { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "PENDING";

        public DateTime? PaymentDueDate { get; set; }

        public string? Notes { get; set; }

        public bool CreatedOffline { get; set; }

        public DateTime? SyncedAt { get; set; }

        // Navigation

        public User Officer { get; set; } = null!;

        public Driver Driver { get; set; } = null!;

        public Vehicle Vehicle { get; set; } = null!;

        public PoliceStation Station { get; set; } = null!;

        public ICollection<FineViolation> FineViolations { get; set; }
            = new List<FineViolation>();

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}
