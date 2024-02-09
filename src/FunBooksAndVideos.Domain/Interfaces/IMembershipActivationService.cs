using FunBooksAndVideos.Domain.Dtos;

namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IMembershipActivationService
    {
        Task ActivateMembership(PurchaseOrderRequetDto purchase);
    }
}
