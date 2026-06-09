using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Commands.UpdateDriver
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IDriverRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDriverHandler(
            IDriverRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            UpdateDriverCommand request,
            CancellationToken cancellationToken)
        {
            var driver = await _repository
                .GetByIdAsync(request.DriverId);

            if (driver == null)
                throw new Exception("Driver not found");

            driver.LicenseNumber = request.LicenseNumber;
            driver.NICNumber = request.NICNumber;
            driver.FirstName = request.FirstName;
            driver.LastName = request.LastName;
            driver.DateOfBirth = request.DateOfBirth;
            driver.MobileNumber = request.MobileNumber;
            driver.Email = request.Email;
            driver.Address = request.Address;
            driver.LicenseType = request.LicenseType;
            driver.LicenseExpiry = request.LicenseExpiry;
            driver.ModifiedAt = DateTime.UtcNow;

            _repository.Update(driver);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
