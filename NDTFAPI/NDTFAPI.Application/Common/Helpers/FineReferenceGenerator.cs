using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Common.Helpers
{
    public static class FineReferenceGenerator
    {
        public static string Generate()
        {
            return $"FN-{DateTime.UtcNow:yyyyMMddHHmmss}";
        }
    }
}
