using MediatR;
using NDTFAPI.Application.Features.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesQuery()
    : IRequest<List<RoleDto>>;
}
