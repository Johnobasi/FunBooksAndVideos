using FluentAssertions;
using FunBooksAndVideos.Api.Controllers;
using FunBooksAndVideos.Application.Features.Queries;
using FunBooksAndVideos.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FunBooksAndVideos.Api.test
{
    public class FunBooksAndVideosControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<FunBooksAndVideosController>> _logger;
        private readonly FunBooksAndVideosController _controller;
        public FunBooksAndVideosControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<FunBooksAndVideosController>>();
            _controller = new FunBooksAndVideosController(_mediator.Object, _logger.Object);
        }

        [Fact]
        public async Task ProcessCustomerPurchaseOrder_WhenProductTypeIsNotNull_ReturnsOkResult()
        {
            // Arrange
            var request = new ProcessPurchaseOrderQuery
                 (new Domain.Dtos.PurchaseOrderRequetDto
                 {
                     CustomerId = Guid.NewGuid(),
                     PurchaseoRderId = Guid.NewGuid(),
                     TotalPrice = 1,
                     ItemLines = new List<Domain.Dtos.ItemLineDto>
                     {
                        new Domain.Dtos.ItemLineDto
                        {
                            Name = "lorem ipsum",
                            ProductType = ProductTypes.None,
                            MembershipType = MembershipType.None
                        }
                     }
                 });
            
            // Act
            _mediator.Setup(x => x.Send(request, It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var result = await _controller.ProcessCustomer(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.Should().Be(true);
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task ProcessCustomerPurchaseOrder_WhenProductTypeIsNull_ReturnsBadRequest()
        {
            // Arrange
            var request = new ProcessPurchaseOrderQuery
                 (new Domain.Dtos.PurchaseOrderRequetDto
                 {
                     CustomerId = Guid.NewGuid(),
                     PurchaseoRderId = Guid.NewGuid(),
                     TotalPrice = 1,
                     ItemLines = new List<Domain.Dtos.ItemLineDto>
                     {
                        new Domain.Dtos.ItemLineDto
                        {
                            Name = "lorem ipsum test",
                            ProductType = 0,
                            MembershipType = 0
                        }
                     }
                 });

            // Act
            _mediator.Setup(x => x.Send(request, It.IsAny<CancellationToken>())).ReturnsAsync(false);
            var result = await _controller.ProcessCustomer(request);

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            badRequestResult.Value.Should().Be(false);
        }
    }
}