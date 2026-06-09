using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.DTOs
{
    public class FineDetailsDto
    {
        public int FineId { get; set; }

        public string FineReference { get; set; } = string.Empty;

        public string DriverName { get; set; } = string.Empty;

        public string VehicleNumber { get; set; } = string.Empty;

        public string OfficerName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }

        public List<FineViolationDto> Violations { get; set; }
            = new();
    }
}
