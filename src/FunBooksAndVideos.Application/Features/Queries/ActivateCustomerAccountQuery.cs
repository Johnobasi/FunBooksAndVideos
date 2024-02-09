using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using MediatR;

namespace FunBooksAndVideos.Application.Features.Queries
{
    public class ActivateCustomerAccountQuery : IRequest<bool>
    {
        public PurchaseOrderRequetDto PurchaseOrders { get; set; }
        public ActivateCustomerAccountQuery(PurchaseOrderRequetDto purchaseOrder)
        {
            PurchaseOrders = purchaseOrder;
        }
    }
}
