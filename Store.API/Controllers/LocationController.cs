using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.MediatRHandlers.Requests.LocationRequests;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] string? locationType, 
            [FromQuery] DateOnly? fromDate, 
            [FromQuery] DateOnly? toDate, 
            CancellationToken ct)
        {
            var request = new GetLocationsRequest(locationType, fromDate, toDate);
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest request, CancellationToken ct)
        {
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest();

            return Ok(result);
        }
    }
}
