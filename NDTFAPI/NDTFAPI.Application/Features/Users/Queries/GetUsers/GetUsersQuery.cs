using MediatR;
using NDTFAPI.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Queries.GetUsers
{
    public record GetUsersQuery(
        string? Search,
        int PageNumber = 1,
        int PageSize = 10
    ) : IRequest<List<UserDto>>;
}
