using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDTFAPI.Application.Features.Vehicles.Commands.CreateVehicle;
using NDTFAPI.Application.Features.Vehicles.Commands.DeleteVehicle;
using NDTFAPI.Application.Features.Vehicles.Commands.UpdateVehicle;
using NDTFAPI.Application.Features.Vehicles.Queries.GetVehicleById;
using NDTFAPI.Application.Features.Vehicles.Queries.GetVehicles;

namespace NDTFAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateVehicleCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(
                new GetVehicleByIdQuery(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _mediator.Send(
                new GetVehiclesQuery(
                    search,
                    pageNumber,
                    pageSize)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateVehicleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(
                new DeleteVehicleCommand(id)));
        }
    }
}
