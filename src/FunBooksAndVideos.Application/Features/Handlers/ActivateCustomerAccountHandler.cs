using FunBooksAndVideos.Application.Features.Queries;
using FunBooksAndVideos.Domain.Interfaces;
using MediatR;

namespace FunBooksAndVideos.Application.Features.Handlers
{

    public class ActivateCustomerAccountHandler : IRequestHandler<ActivateCustomerAccountQuery, bool>
    {
        private readonly IMembershipActivationService _membershipActivationService;
        public ActivateCustomerAccountHandler(IMembershipActivationService membershipActivationService)
        {
            _membershipActivationService = membershipActivationService;
        }
        public async Task<bool> Handle(ActivateCustomerAccountQuery request, CancellationToken cancellationToken)
        {
            var requestObject = request.PurchaseOrders; 
            await _membershipActivationService.ActivateMembership(requestObject.CustomerId.ToString(), requestObject.Membership.MembershipType);

            return true;
            
        }
    }
}
