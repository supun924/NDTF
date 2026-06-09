using MediatR;
using NDTFAPI.Application.Interfaces;
using NDTFAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(
            IUserRepository repository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser =
                await _repository.GetByUsernameAsync(
                    request.Username);

            if (existingUser != null)
                throw new Exception(
                    "Username already exists");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                PasswordHash =
                    _passwordHasher.Hash(request.Password),
                RoleId = request.RoleId,
                IsActive = true
            };

            await _repository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return user.UserId;
        }
    }
}
