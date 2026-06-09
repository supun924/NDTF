using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleHandler : IRequestHandler<UpdateVehicleCommand, bool>
    {
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVehicleHandler(
            IVehicleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            UpdateVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _repository.GetByIdAsync(request.VehicleId);

            if (vehicle == null)
                throw new Exception("Vehicle not found");

            vehicle.RegistrationNumber = request.RegistrationNumber;
            vehicle.DriverId = request.DriverId;
            vehicle.VehicleType = request.VehicleType;
            vehicle.Brand = request.Brand;
            vehicle.Model = request.Model;
            vehicle.Color = request.Color;

            _repository.Update(vehicle);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
