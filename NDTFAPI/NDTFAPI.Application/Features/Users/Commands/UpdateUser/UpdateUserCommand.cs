using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
    int UserId,
    string FirstName,
    string LastName,
    string Email,
    int RoleId,
    bool IsActive
) : IRequest<bool>;
}
