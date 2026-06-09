using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.CreateVehicle
{
    public record CreateVehicleCommand(
        string RegistrationNumber,
        int DriverId,
        string VehicleType,
        string Brand,
        string Model,
        string Color
    ) : IRequest<int>;
}
