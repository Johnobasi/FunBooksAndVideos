namespace FunBooksAndVideos.Domain.Dtos
{
    public class UpdateCustomerDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }
    }
}
