using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public record UpdateVehicleCommand(
        int VehicleId,
        string RegistrationNumber,
        int DriverId,
        string VehicleType,
        string Brand,
        string Model,
        string Color
    ) : IRequest<bool>;
}
