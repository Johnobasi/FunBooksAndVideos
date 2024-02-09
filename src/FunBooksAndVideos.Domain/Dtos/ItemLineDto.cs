using FunBooksAndVideos.Domain.Enum;
namespace FunBooksAndVideos.Domain.Dtos;

public class ItemLineDto
{
    public string Name { get; set; }
    public ProductTypes ProductType { get; set; }
    public MembershipType MembershipType { get; set; }
}
