using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(
        int RoleId,
        int PoliceStationId,
        string FirstName,
        string LastName,
        string ServiceNumber,
        string Email,
        string MobileNumber,
        string Username,
        string Password
) : IRequest<int>;
}
