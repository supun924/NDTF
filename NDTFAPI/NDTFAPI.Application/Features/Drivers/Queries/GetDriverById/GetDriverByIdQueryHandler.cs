using MediatR;
using NDTFAPI.Application.Features.Drivers.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDriverById
{
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverDto>
    {
        private readonly IDriverRepository _repository;

        public GetDriverByIdQueryHandler(
            IDriverRepository repository)
        {
            _repository = repository;
        }

        public async Task<DriverDto> Handle(
            GetDriverByIdQuery request,
            CancellationToken cancellationToken)
        {
            var driver = await _repository
                .GetByIdAsync(request.DriverId);

            if (driver == null)
                throw new Exception("Driver not found");

            return new DriverDto
            {
                DriverId = driver.DriverId,
                LicenseNumber = driver.LicenseNumber,
                NICNumber = driver.NICNumber,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                DateOfBirth = driver.DateOfBirth,
                MobileNumber = driver.MobileNumber,
                Email = driver.Email,
                Address = driver.Address,
                LicenseType = driver.LicenseType,
                LicenseExpiry = driver.LicenseExpiry
            };
        }
    }
}
