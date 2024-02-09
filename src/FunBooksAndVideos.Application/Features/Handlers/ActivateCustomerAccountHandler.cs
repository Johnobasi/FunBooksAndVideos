using FunBooksAndVideos.Application.Features.Queries;
using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Interfaces;
using MediatR;

namespace FunBooksAndVideos.Application.Features.Handlers
{

    public class ActivateCustomerAccountHandler : IRequestHandler<ActivateCustomerAccountQuery, bool>
    {
        private readonly IMembershipActivationService _membershipActivationService;
        private readonly IShippingSlipService _shippingSlipService;
        public ActivateCustomerAccountHandler(IMembershipActivationService membershipActivationService, IShippingSlipService shippingSlipService)
        {
            _membershipActivationService = membershipActivationService;
            _shippingSlipService = shippingSlipService;
        }
        public async Task<bool> Handle(ActivateCustomerAccountQuery request, CancellationToken cancellationToken)
        {
            var requestObject = request.PurchaseOrders;
            if (requestObject !=null)
            {
                if (requestObject.ItemLines.Any(x => x.MembershipType != MembershipType.None))
                {
                    await _membershipActivationService.ActivateMembership(requestObject);
                }
                else if (requestObject.ItemLines.Any(x => x.ProductType != ProductTypes.None))
                {
                    await _shippingSlipService.GenerateShippingSlip(requestObject);
                }
            }

            return true;
            
        }
    }
}
