using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Domain.Models
{
    public class Membership
    {
        public Guid Id { get; set; }
        public MembershipType MembershipType { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
