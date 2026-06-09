using MediatR;
using NDTFAPI.Application.Features.Vehicles.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly IVehicleRepository _repository;

        public GetVehicleByIdQueryHandler(
            IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<VehicleDto> Handle(
            GetVehicleByIdQuery request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _repository.GetByIdAsync(request.VehicleId);

            if (vehicle == null)
                throw new Exception("Vehicle not found");

            return new VehicleDto
            {
                VehicleId = vehicle.VehicleId,
                RegistrationNumber = vehicle.RegistrationNumber,
                VehicleType = vehicle.VehicleType,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                DriverName = $"{vehicle.Driver.FirstName} {vehicle.Driver.LastName}"
            };
        }
    }
}
