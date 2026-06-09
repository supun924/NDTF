using MediatR;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(
            UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            if (user == null)
                throw new Exception("User not found");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.RoleId = request.RoleId;
            user.IsActive = request.IsActive;

            user.ModifiedAt = DateTime.UtcNow;

            _repository.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
