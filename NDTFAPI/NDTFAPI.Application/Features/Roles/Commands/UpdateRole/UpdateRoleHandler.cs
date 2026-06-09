using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Commands.UpdateRole
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            UpdateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role =
                await _repository.GetByIdAsync(request.RoleId);

            if (role == null)
                throw new Exception("Role not found");

            role.RoleName = request.RoleName;

            role.ModifiedAt = DateTime.UtcNow;

            _repository.Update(role);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
