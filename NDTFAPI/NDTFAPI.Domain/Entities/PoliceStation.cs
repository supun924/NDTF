using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class PoliceStation : BaseEntity
    {
        public int StationId { get; set; }

        public int RegionId { get; set; }

        public string StationName { get; set; } = string.Empty;

        public string? StationCode { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }

        // Navigation

        public ICollection<User> Users { get; set; }
            = new List<User>();

        public ICollection<Fine> Fines { get; set; }
            = new List<Fine>();
    }
}
