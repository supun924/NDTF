using MediatR;
using NDTFAPI.Application.Features.Drivers.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Queries.GetDrivers
{
    public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, List<DriverDto>>
    {
        private readonly IDriverRepository _repository;

        public GetDriversQueryHandler(
            IDriverRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DriverDto>> Handle(
            GetDriversQuery request,
            CancellationToken cancellationToken)
        {
            var drivers = await _repository.SearchAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            return drivers.Select(driver => new DriverDto
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
            }).ToList();
        }
    }
}
