using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDTFAPI.Application.Features.Drivers.Queries.GetDashboardStats;
using NDTFAPI.Application.Features.Fines.Commands.IssueFine;
using NDTFAPI.Application.Features.Fines.Queries.GetFineById;
using NDTFAPI.Application.Features.Fines.Queries.GetFinesQuery;

namespace NDTFAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> IssueFine(
            [FromBody] IssueFineCommand command)
        {
            var fineId = await _mediator.Send(command);

            return Ok(new
            {
                Success = true,
                Message = "Fine issued successfully.",
                FineId = fineId
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetFineByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? search)
        {
            var result = await _mediator.Send(
                new GetFinesQuery(search));

            return Ok(result);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var result = await _mediator.Send(
                new GetDashboardStatsQuery());

            return Ok(result);
        }
    }
}
