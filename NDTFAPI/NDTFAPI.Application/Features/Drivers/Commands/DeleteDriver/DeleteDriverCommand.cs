using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Commands.DeleteDriver
{
    public record DeleteDriverCommand(int DriverId)
    : IRequest<bool>;
}
