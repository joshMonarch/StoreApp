using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiltered([FromQuery] string? categoryName, [FromQuery] DateOnly? fromDate, [FromQuery] DateOnly? toDate, CancellationToken ct)
        {
            var request = new GetCategoriesRequest(categoryName, fromDate, toDate);
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken ct)
        {
            var result = await _mediator.Send(request, ct);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
