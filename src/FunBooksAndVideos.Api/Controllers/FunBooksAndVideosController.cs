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


        [HttpPost("ActivateCustomerAccount")]
        public async Task<IActionResult> ActivateCustomerAccount([FromBody] ActivateCustomerAccountQuery request)
        {
            var result = await _mediator.Send(request);
            var resultJson = JsonConvert.SerializeObject(result);

            _logger.LogInformation($"ActivateCustomerAccount completed. Result: {resultJson}");
            return Ok(result);
        }
    }
}
