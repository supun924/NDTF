using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Commands.CreateDriver
{
    public record CreateDriverCommand(
        string LicenseNumber,
        string NICNumber,
        string FirstName,
        string LastName,
        DateTime? DateOfBirth,
        string MobileNumber,
        string Email,
        string Address,
        string LicenseType,
        DateTime? LicenseExpiry
    ) : IRequest<int>;
}
