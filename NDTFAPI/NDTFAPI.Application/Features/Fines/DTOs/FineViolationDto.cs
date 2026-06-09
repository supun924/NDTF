using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.DTOs
{
    public class FineViolationDto
    {
        public int ViolationId { get; set; }

        public string ViolationCode { get; set; } = string.Empty;

        public string ViolationName { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}
