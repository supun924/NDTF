using MediatR;
using NDTFAPI.Application.Features.Users.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(
            IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(
                request.UserId);

            if (user == null)
                throw new Exception("User not found");

            return new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                RoleName = user.Role.RoleName,
                IsActive = user.IsActive
            };
        }
    }
}
