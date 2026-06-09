using MediatR;
using NDTFAPI.Application.Features.Vehicles.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Queries.GetVehicles
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<VehicleDto>>
    {
        private readonly IVehicleRepository _repository;

        public GetVehiclesQueryHandler(
            IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VehicleDto>> Handle(
            GetVehiclesQuery request,
            CancellationToken cancellationToken)
        {
            var vehicles = await _repository.SearchAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            return vehicles.Select(vehicle => new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                RegistrationNumber = vehicle.RegistrationNumber,
                VehicleType = vehicle.VehicleType,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                DriverName = $"{vehicle.Driver.FirstName} {vehicle.Driver.LastName}"
            }).ToList();
        }
    }
}
