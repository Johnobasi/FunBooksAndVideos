namespace FunBooksAndVideos.Domain.Entities
{
    public class PurchaseOrder
    {
      
        public Guid PurchaseOrderID { get; set; }
        public double TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public List<ItemLine> ItemLines { get; set; }
        public Membership Membership { get; set; }
    }

}
