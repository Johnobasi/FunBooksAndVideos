using FunBooksAndVideos.Domain.Enum;

namespace FunBooksAndVideos.Domain.Models
{
    public class ItemLine
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypes ProductType { get; set; }
        public MembershipType MembershipType { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
