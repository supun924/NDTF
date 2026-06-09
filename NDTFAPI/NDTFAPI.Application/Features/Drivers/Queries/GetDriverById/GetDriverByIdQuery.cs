using MediatR;
using NDTFAPI.Application.Features.Drivers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDriverById
{
    public record GetDriverByIdQuery(int DriverId)
    : IRequest<DriverDto>;
}
