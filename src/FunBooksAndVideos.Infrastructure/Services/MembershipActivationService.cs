using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
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
        public async Task ActivateMembership(string customerId, MembershipType membershipType)
        {
            Customer customer = await _customerServices.GetCustomerById(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            if (customer.IsMember)
            {
                throw new Exception("Customer is already a member");
            }

            if (membershipType != MembershipType.None)
            {
                customer.Membership = new Membership
                {
                    MembershipType = membershipType,
                    Id = Guid.NewGuid()
                };
            }
            await _customerServices.UpdateCustomer(customer);
        }   
    }
}
