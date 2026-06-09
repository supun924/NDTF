using MediatR;
using NDTFAPI.Application.Features.Users.DTOs;
using NDTFAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(
            IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _repository.SearchAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                RoleName = user.Role.RoleName,
                IsActive = user.IsActive
            }).ToList();
        }
    }
}
