using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public int DriverId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;

        public string NICNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; } 

        public string MobileNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string LicenseType { get; set; } = string.Empty;

        public DateTime? LicenseExpiry { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
            = new List<Vehicle>();
    }
}
