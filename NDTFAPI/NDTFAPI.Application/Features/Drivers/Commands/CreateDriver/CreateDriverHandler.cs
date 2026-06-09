using MediatR;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Commands.CreateDriver
{
    internal class CreateDriverHandler : IRequestHandler<CreateDriverCommand, int>
    {
        private readonly IDriverRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDriverHandler(
            IDriverRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateDriverCommand request,
            CancellationToken cancellationToken)
        {
            var driver = new Driver
            {
                LicenseNumber = request.LicenseNumber,
                NICNumber = request.NICNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                MobileNumber = request.MobileNumber,
                Email = request.Email,
                Address = request.Address,
                LicenseType = request.LicenseType,
                LicenseExpiry = request.LicenseExpiry,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(driver);

            await _unitOfWork.SaveChangesAsync();

            return driver.DriverId;
        }
    }
}
