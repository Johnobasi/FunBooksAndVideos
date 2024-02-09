using FunBooksAndVideos.Domain.Enum;

namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IMembershipActivationService
    {
        Task ActivateMembership(string customerId, MembershipType membershipType);
    }
}
