using FunBooksAndVideos.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessPurchaseOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProcessPurchaseOrderController> _logger;
        public ProcessPurchaseOrderController(IMediator mediator, ILogger<ProcessPurchaseOrderController> logger)
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
