namespace FunBooksAndVideos.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }
    }
}
