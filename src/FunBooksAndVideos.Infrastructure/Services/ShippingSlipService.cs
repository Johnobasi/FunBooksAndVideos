using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Interfaces;

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
            foreach (var itemLine in purchaseOrder.ItemLines)
            {
                if (IsPhysicalProduct(itemLine.ProductType))
                {
                    var shippingSlip = new ShippingSlip
                    {
                        CustomerId = purchaseOrder.CustomerId.ToString(),
                        ProductType = itemLine.ProductType.ToString(),
                        ShippingDate = DateTime.UtcNow
                    };

                    await _shippingSlip.AddShippingSlip(shippingSlip);
                    PrintShippingSlip(shippingSlip);
                }
            }
        }

        #region Private Methods
        private void PrintShippingSlip(ShippingSlip shippingSlip)
        {
            Console.WriteLine("========== Shipping Slip Information ==========");
            Console.WriteLine("Shipping Slip Information:");
            Console.WriteLine($"Customer ID: {shippingSlip.CustomerId}");
            Console.WriteLine($"Product Type: {shippingSlip.ProductType}");
            Console.WriteLine($"Shipping Date: {shippingSlip.ShippingDate}");
            Console.WriteLine("===============================================");
        }

        private bool IsPhysicalProduct(ProductTypes productType)
        {
            foreach (ProductTypes physicalProductType in Enum.GetValues(typeof(ProductTypes)))
            {
                if (physicalProductType == productType)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}