using FunBooksAndVideos.Domain.Entities;

namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IShippingSlip
    {
        Task<int> AddShippingSlip(ShippingSlip shippingSlip);
    }
}
