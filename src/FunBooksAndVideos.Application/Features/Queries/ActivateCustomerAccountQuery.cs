using FunBooksAndVideos.Domain.Entities;
using MediatR;

namespace FunBooksAndVideos.Application.Features.Queries
{
    public class ActivateCustomerAccountQuery : IRequest<bool>
    {
        public PurchaseOrder PurchaseOrders { get; set; }
        public ActivateCustomerAccountQuery(PurchaseOrder purchaseOrder)
        {
            PurchaseOrders = purchaseOrder;
        }
    }
}
