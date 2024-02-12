using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }

        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }
        public List<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
