using FunBooksAndVideos.Domain.Enum;

namespace FunBooksAndVideos.Domain.Entities
{
    public class ShippingSlip
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public ProductTypes ProductType { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
