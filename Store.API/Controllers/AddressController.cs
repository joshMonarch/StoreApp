using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.MediatRHandlers.Requests;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] int? userId, 
            [FromQuery] string? country, 
            [FromQuery] string? region, 
            [FromQuery] string? city, 
            [FromQuery] DateOnly? fromDate, 
            [FromQuery] DateOnly? toDate, 
            CancellationToken ct)
        {
            var request = new GetAddressesRequest(userId, country, region, city, fromDate, toDate);
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
