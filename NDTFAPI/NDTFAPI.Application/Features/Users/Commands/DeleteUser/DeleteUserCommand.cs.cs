using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(int UserId)
    : IRequest<bool>;
}
