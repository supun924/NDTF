using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Commands.CreateRole
{
    public record CreateRoleCommand(string RoleName) : IRequest<int>;
}
