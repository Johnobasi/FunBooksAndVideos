using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Interfaces;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class ShippingService : IShippingSlip
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ShippingService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddShippingSlip(ShippingSlip shippingSlip)
        {
                
             _applicationDbContext.ShippingSlips.Add(shippingSlip);
            await _applicationDbContext.SaveChangesAsync();
            return shippingSlip.Id;

        }
    }
}
