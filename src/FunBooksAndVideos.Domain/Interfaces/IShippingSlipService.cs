namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IShippingSlipService
    {
        Task GenerateShippingSlip(string customerId, string productType);
    }
}
