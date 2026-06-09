using MediatR;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVehicleHandler(
            IVehicleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle
            {
                RegistrationNumber = request.RegistrationNumber,
                DriverId = request.DriverId,
                VehicleType = request.VehicleType,
                Brand = request.Brand,
                Model = request.Model,
                Color = request.Color,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(vehicle);

            await _unitOfWork.SaveChangesAsync();

            return vehicle.VehicleId;
        }
    }
}
