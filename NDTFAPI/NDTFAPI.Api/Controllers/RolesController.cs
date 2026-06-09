using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDTFAPI.Application.Features.Roles.Commands.CreateRole;
using NDTFAPI.Application.Features.Roles.Commands.DeleteRole;
using NDTFAPI.Application.Features.Roles.Commands.UpdateRole;
using NDTFAPI.Application.Features.Roles.Queries.GetAllRoles;

namespace NDTFAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _mediator.Send(
                    new GetAllRolesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateRoleCommand command)
        {
            return Ok(
                await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateRoleCommand command)
        {
            return Ok(
                await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(
                await _mediator.Send(
                    new DeleteRoleCommand(id)));
        }
    }
}
