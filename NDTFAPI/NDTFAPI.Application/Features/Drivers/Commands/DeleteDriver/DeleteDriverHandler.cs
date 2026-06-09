using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IDriverRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDriverHandler(
            IDriverRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            DeleteDriverCommand request,
            CancellationToken cancellationToken)
        {
            var driver = await _repository
                .GetByIdAsync(request.DriverId);

            if (driver == null)
                throw new Exception("Driver not found");

            _repository.Delete(driver);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
