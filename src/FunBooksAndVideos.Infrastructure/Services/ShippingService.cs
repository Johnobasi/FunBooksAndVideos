using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class ShippingService : IShippingSlip
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<ShippingService> _logger;
        public ShippingService(ApplicationDbContext applicationDbContext, ILogger<ShippingService> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }
        public async Task<int> AddShippingSlip(ShippingSlip shippingSlip)
        {
            try
            {
                _applicationDbContext.ShippingSlips.Add(shippingSlip);
                await _applicationDbContext.SaveChangesAsync();
                return shippingSlip.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding shipping slip");
                return 0;
            }


        }
    }
}
