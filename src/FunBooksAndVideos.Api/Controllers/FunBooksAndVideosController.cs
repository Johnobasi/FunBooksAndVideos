using FunBooksAndVideos.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FunBooksAndVideos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunBooksAndVideosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FunBooksAndVideosController> _logger;
        public FunBooksAndVideosController(IMediator mediator, ILogger<FunBooksAndVideosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost("ProcessCustomerPurchaseOrder")]
        public async Task<IActionResult> ProcessCustomer([FromBody] ProcessPurchaseOrderQuery request)
        {
            _logger.LogInformation("ProcessCustomerPurchaseOrder completed");
            var result = await _mediator.Send(request);         
            return Ok(result);
        }
    }
}
