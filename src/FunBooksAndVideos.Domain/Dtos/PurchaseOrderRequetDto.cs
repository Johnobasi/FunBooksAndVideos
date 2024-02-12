
namespace FunBooksAndVideos.Domain.Dtos;
public class PurchaseOrderRequetDto
{
    public Guid CustomerId { get; set; }
    public Guid PurchaseOrderId { get; set; }
    public double TotalPrice { get; set; }
    public List<ItemLineDto> ItemLines { get; set; }
}