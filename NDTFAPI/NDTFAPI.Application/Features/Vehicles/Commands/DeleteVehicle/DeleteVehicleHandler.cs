using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleHandler(
            IVehicleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            DeleteVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _repository.GetByIdAsync(request.VehicleId);

            if (vehicle == null)
                throw new Exception("Vehicle not found");

            _repository.Delete(vehicle);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
