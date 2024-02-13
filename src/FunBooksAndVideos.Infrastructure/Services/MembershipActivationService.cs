using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Exceptions;
using FunBooksAndVideos.Domain.Interfaces;
using FunBooksAndVideos.Domain.Models;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class MembershipActivationService : IMembershipActivationService
    {
        private readonly ICustomerServices _customerServices;
        private readonly ILogger<MembershipActivationService> _logger;
        public MembershipActivationService(ICustomerServices customerServices, ILogger<MembershipActivationService> logger)
        {
            _customerServices = customerServices;
            _logger = logger;
        }
        public async Task ActivateMembership(PurchaseOrderRequetDto purchase)
        {
            try
            {
                Customer customer = await _customerServices.GetCustomerById(purchase.CustomerId.ToString());
                if (customer == null)
                {
                    throw new NotFoundException("Customer not found");
                }

                if (customer.IsMember)
                {
                    throw new InvalidOperationExceptions("Customer is already a member");
                }

                var validMembershipTypes = Enum.GetValues(typeof(MembershipType))
                                .Cast<MembershipType>()
                                    .Where(mt => mt != MembershipType.None);

                foreach (var itemLine in purchase.ItemLines)
                {
                    if (validMembershipTypes.Contains(itemLine.MembershipType))
                    {
                        // Activate membership for each valid type found
                        customer.Membership = new Membership
                        {
                            MembershipType = itemLine.MembershipType,
                            Id = Guid.NewGuid(),
                            CustomerId = customer.Id,
                            Customer = customer
                        };
                    }
                }

                //update customer only if memberships are activated
                if (customer.Membership != null)
                {
                    await _customerServices.UpdateCustomer(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error activating membership");
            }

        }
    }
}
