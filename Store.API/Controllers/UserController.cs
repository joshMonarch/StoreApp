using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.MediatRHandlers.Requests;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] DateOnly? fromDate,
            [FromQuery] DateOnly? toDate,
            [FromQuery] DateOnly? fromBirthDate,
            [FromQuery] DateOnly? toBirthDate,
            CancellationToken ct)
        {
            var request = new GetUsersRequest(fromDate, toDate, fromBirthDate, toBirthDate);
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
