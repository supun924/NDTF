using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class LicenseConfiscation : BaseEntity
    {
        public int ConfiscationId { get; set; }

        public int FineId { get; set; }

        public string LicenseNumber { get; set; } = string.Empty;

        public DateTime ConfiscatedDate { get; set; }

        public DateTime? ReleasedDate { get; set; }

        public Fine Fine { get; set; } = null!;
    }
}
