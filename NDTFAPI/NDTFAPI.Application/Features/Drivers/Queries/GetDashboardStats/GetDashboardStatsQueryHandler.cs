using MediatR;
using NDTFAPI.Application.Features.Fines.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDashboardStats
{
    public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery,
        DashboardStatsDto>
    {
        private readonly IFineRepository _repository;

        public GetDashboardStatsQueryHandler(
            IFineRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatsDto> Handle(
            GetDashboardStatsQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetDashboardStatsAsync();
        }
    }
}
