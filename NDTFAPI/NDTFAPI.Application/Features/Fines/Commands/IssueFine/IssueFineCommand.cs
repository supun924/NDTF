using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Commands.IssueFine
{
    public record IssueFineCommand(
        int OfficerId,
        int DriverId,
        int VehicleId,
        int StationId,
        List<int> ViolationIds,
        string? Notes
    ) : IRequest<int>;
}
