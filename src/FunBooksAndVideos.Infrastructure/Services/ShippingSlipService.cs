using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Interfaces;
using System.Text;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class ShippingSlipService : IShippingSlipService
    {

        private readonly IShippingSlip _shippingSlip;
        public ShippingSlipService(IShippingSlip shippingSlip)
        {
            _shippingSlip = shippingSlip;
        }

        public async Task GenerateShippingSlip(PurchaseOrderRequetDto purchaseOrder)
        {
            // filter out the physical products 
            var validproductTypes = Enum.GetValues(typeof(ProductTypes))
                .Cast<ProductTypes>()
                .Where(mt => mt != ProductTypes.None);

            var validproductType = purchaseOrder.ItemLines
                .Select(itemLine => itemLine.ProductType)
                .FirstOrDefault(validproductTypes.Contains);

            if (validproductType != ProductTypes.None)
            {
                var shippingSlip = new ShippingSlip
                {
                    CustomerId = purchaseOrder.CustomerId.ToString(),
                    ProductType = validproductType,
                    ShippingDate = DateTime.UtcNow
                };

                //persist shipping slip to the database
                await _shippingSlip.AddShippingSlip(shippingSlip);

                //print shipping slip
                PrintShippingSlip(purchaseOrder);
            }
        }

        #region Private Methods
        private void PrintShippingSlip(PurchaseOrderRequetDto purchaseOrder)
        {
            StringBuilder shippingSlip = new StringBuilder();

            shippingSlip.AppendLine("========== Shipping Slip Information ==========");

            shippingSlip.AppendLine("Shipping Slip Information:");

            shippingSlip.AppendLine($"Customer ID: {purchaseOrder.CustomerId}");
            shippingSlip.AppendLine($"Purchase Order Id:{purchaseOrder.PurchaseOrderId}");
            shippingSlip.AppendLine($"Total: {purchaseOrder.TotalPrice}");
            
            shippingSlip.AppendLine("Item Lines");
            foreach (var item in purchaseOrder.ItemLines)
            {
                shippingSlip.AppendLine($"Item Name: {item.Name}");
                shippingSlip.AppendLine($"Product Type: {item.ProductType}");
                shippingSlip.AppendLine($"Membership Type: {item.MembershipType}");
            }

            shippingSlip.AppendLine("===============================================");
        }
        #endregion
    }
}