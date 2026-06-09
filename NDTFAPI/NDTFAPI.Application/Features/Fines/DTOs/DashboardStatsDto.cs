using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.DTOs
{
    public class DashboardStatsDto
    {
        public int TotalFines { get; set; }

        public int PendingFines { get; set; }

        public int PaidFines { get; set; }

        public decimal TotalRevenue { get; set; }

        public int TotalDrivers { get; set; }

        public int TotalVehicles { get; set; }
    }
}
