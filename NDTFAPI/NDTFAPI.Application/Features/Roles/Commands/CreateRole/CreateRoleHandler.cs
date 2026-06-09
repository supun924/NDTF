using MediatR;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Commands.CreateRole
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var existing =
                await _repository.GetByNameAsync(request.RoleName);

            if (existing != null)
                throw new Exception("Role already exists.");

            var role = new Role
            {
                RoleName = request.RoleName
            };

            await _repository.AddAsync(role);

            await _unitOfWork.SaveChangesAsync();

            return role.RoleId;
        }
    }
}
