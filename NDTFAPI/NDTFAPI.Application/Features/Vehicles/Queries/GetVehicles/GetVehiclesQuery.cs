using MediatR;
using NDTFAPI.Application.Features.Vehicles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Queries.GetVehicles
{
    public record GetVehiclesQuery(
        string? Search,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<List<VehicleDto>>;
}
