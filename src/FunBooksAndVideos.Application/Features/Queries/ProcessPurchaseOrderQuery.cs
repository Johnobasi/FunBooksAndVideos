using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using MediatR;

namespace FunBooksAndVideos.Application.Features.Queries
{
    public class ProcessPurchaseOrderQuery : IRequest<bool>
    {
        public PurchaseOrderRequetDto PurchaseOrders { get; set; }
        public ProcessPurchaseOrderQuery(PurchaseOrderRequetDto purchaseOrder)
        {
            PurchaseOrders = purchaseOrder;
        }
    }
}
