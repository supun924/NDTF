using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password,
    int RoleId
) : IRequest<int>;
}
