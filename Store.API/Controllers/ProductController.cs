using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.MediatRHandlers.Requests.ProductRequest;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiltered(
            [FromQuery] int? userId,
            [FromQuery] int? categoryId,
            [FromQuery] DateOnly? fromDate,
            [FromQuery] DateOnly? toDate,
            CancellationToken ct)
        {
            var request = new GetProductsRequest(userId, categoryId, fromDate, toDate);
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken ct)
        {
            var result = await _mediator.Send(request, ct);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
