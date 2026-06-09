using NDTFAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Domain.Entities
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
