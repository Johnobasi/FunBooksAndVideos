using FunBooksAndVideos.Domain.Dtos;

namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IShippingSlipService
    {
        Task GenerateShippingSlip(PurchaseOrderRequetDto purchaseOrder);
    }
}
