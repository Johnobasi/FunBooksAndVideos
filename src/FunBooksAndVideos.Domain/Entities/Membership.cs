using FunBooksAndVideos.Domain.Enum;

namespace FunBooksAndVideos.Domain.Entities
{
    public class Membership
    {
        public Guid Id { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}
