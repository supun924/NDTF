using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.DTOs
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }

        public string RegistrationNumber { get; set; } = string.Empty;

        public string VehicleType { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public string DriverName { get; set; } = string.Empty;
    }
}
