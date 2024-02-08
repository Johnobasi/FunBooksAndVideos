namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface IMembershipActivationService
    {
        Task ActivateMembership(string customerId, string membershipType);
    }
}
