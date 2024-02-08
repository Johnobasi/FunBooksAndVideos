using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Interfaces;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class MembershipActivationService : IMembershipActivationService
    {
        private readonly ICustomerServices _customerServices;
        public MembershipActivationService(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        public async Task ActivateMembership(string customerId, string membershipType)
        {
            Customer customer = await _customerServices.GetCustomerById(customerId);
            ActivateMembershipForCustomer(customer, membershipType);
           await _customerServices.UpdateCustomer(customer);
        }

        private void ActivateMembershipForCustomer(Customer customer, string membershipType)
        {
            customer.IsMember = true;
            // Activate membership

            if(membershipType == "BookClub")
            {
                // Activate book club membership
            }
            else if (membershipType == "VideoClub")
            {
                // Activate video club membership
            }
        }
    }
}
