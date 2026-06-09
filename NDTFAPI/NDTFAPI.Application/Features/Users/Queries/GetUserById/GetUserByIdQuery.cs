using MediatR;
using NDTFAPI.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int UserId)
        : IRequest<UserDto>;
}
