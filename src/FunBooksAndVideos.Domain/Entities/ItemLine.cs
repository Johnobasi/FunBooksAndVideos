using FunBooksAndVideos.Domain.Enum;

namespace FunBooksAndVideos.Domain.Entities
{
    public class ItemLine
    {
        public Guid Id { get; set; }
        public ItemType Type { get; set; }
        public string Name { get; set; }
    }
}
