using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDTFAPI.Application.Features.Drivers.Commands.CreateDriver;
using NDTFAPI.Application.Features.Drivers.Commands.DeleteDriver;
using NDTFAPI.Application.Features.Drivers.Commands.UpdateDriver;
using NDTFAPI.Application.Features.Drivers.Queries.GetDriverById;
using NDTFAPI.Application.Features.Drivers.Queries.GetDrivers;

namespace NDTFAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriversController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDriverCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetDriverByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetDriversQuery(
                    search,
                    pageNumber,
                    pageSize));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDriverCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteDriverCommand(id));

            return Ok(result);
        }
    }
}
