using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public int VehicleId { get; set; }

        public string RegistrationNumber { get; set; } = string.Empty;

        public int DriverId { get; set; }

        public string VehicleType { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public Driver Driver { get; set; } = null!;
    }
}
