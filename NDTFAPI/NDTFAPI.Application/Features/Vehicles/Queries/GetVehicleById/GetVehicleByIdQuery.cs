using MediatR;
using NDTFAPI.Application.Features.Vehicles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Queries.GetVehicleById
{
    public record GetVehicleByIdQuery(int VehicleId)
        : IRequest<VehicleDto>;
}
