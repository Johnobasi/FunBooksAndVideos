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
            // filter out the physical products and generate shipping slip
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

                await _shippingSlip.AddShippingSlip(shippingSlip);
                PrintShippingSlip(shippingSlip);
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
        #endregion
    }
}