using MediatR;
using NDTFAPI.Application.Features.Fines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDashboardStats
{
    public record GetDashboardStatsQuery()
        : IRequest<DashboardStatsDto>;
}
