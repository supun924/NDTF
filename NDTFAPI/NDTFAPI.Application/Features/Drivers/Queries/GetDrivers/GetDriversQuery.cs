using MediatR;
using NDTFAPI.Application.Features.Drivers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDrivers
{
    public record GetDriversQuery(
        string? Search,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<List<DriverDto>>;
}
