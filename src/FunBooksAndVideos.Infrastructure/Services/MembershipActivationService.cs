using FunBooksAndVideos.Domain.Dtos;
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
        public async Task ActivateMembership(PurchaseOrderRequetDto purchase)
        {
            Customer customer = await _customerServices.GetCustomerById(purchase.CustomerId.ToString());
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            if (customer.IsMember)
            {
                throw new Exception("Customer is already a member");
            }

            // Activate only one membership at a time
            var validMembershipTypes = Enum.GetValues(typeof(MembershipType))
                .Cast<MembershipType>()
                .Where(mt => mt != MembershipType.None);

            var validMembershipType = purchase.ItemLines
                .Select(itemLine => itemLine.MembershipType)
                .FirstOrDefault(validMembershipTypes.Contains);

            if (validMembershipType != MembershipType.None)
            {
                customer.Membership = new Membership
                {
                    MembershipType = validMembershipType,
                    Id = Guid.NewGuid(),
                    CustomerId = customer.Id,
                    Customer = customer
                };


                // Update customer
                await _customerServices.UpdateCustomer(customer);
            }

        }
    }
}
