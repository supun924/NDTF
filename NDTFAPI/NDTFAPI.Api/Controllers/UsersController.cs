using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDTFAPI.Application.Features.Users.Commands.CreateUser;
using NDTFAPI.Application.Features.Users.Commands.DeleteUser;
using NDTFAPI.Application.Features.Users.Commands.UpdateUser;
using NDTFAPI.Application.Features.Users.Queries.GetUserById;
using NDTFAPI.Application.Features.Users.Queries.GetUsers;

namespace NDTFAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateUserCommand command)
        {
            return Ok(
                await _mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetUserByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetUsersQuery(
                    search,
                    pageNumber,
                    pageSize));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteUserCommand(id));

            return Ok(result);
        }
    }
}
