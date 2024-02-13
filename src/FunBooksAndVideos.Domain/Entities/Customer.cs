using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FunBooksAndVideos.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }

        [JsonIgnore]
        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }

        [JsonIgnore]
        public List<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
