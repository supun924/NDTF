using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }

        public int FineId { get; set; }

        public string? PaymentReference { get; set; }

        public string? PaymentMethod { get; set; }

        public decimal Amount { get; set; }

        public string? PaymentStatus { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int? ProcessedBy { get; set; }

        public string? ReceiptPath { get; set; }

        public Fine Fine { get; set; } = null!;

        public User? User { get; set; }
    }
}
