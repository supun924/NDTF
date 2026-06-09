using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Commands.DeleteRole
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleHandler(
            IRoleRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            DeleteRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role =
                await _repository.GetByIdAsync(request.RoleId);

            if (role == null)
                throw new Exception("Role not found");

            _repository.Delete(role);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
