using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public record DeleteVehicleCommand(int VehicleId)
    : IRequest<bool>;
}
