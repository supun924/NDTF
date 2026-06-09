using MediatR;
using NDTFAPI.Application.Features.Roles.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        private readonly IRoleRepository _repository;

        public GetAllRolesQueryHandler(
            IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleDto>> Handle(
            GetAllRolesQuery request,
            CancellationToken cancellationToken)
        {
            var roles = await _repository.GetAllAsync();

            return roles.Select(x => new RoleDto
            {
                RoleId = x.RoleId,
                RoleName = x.RoleName
            }).ToList();
        }
    }
}
