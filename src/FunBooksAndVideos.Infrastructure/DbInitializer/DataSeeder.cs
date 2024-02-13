using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Enum;
using FunBooksAndVideos.Domain.Models;

namespace FunBooksAndVideos.Infrastructure.DbInitializer
{
    public  class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                IsMember = true,
                Membership = new Membership
                {
                    Id = Guid.NewGuid(),
                    MembershipType = MembershipType.Premium
                },
                PurchaseOrder = new List<PurchaseOrder>
                {
                    new PurchaseOrder
                    {
                        Id = Guid.NewGuid(),
                        ItemLines = new List<ItemLine>
                        {
                            new ItemLine
                            {
                                Id = Guid.NewGuid(),
                                ProductType = ProductTypes.Video
                            }
                        }
                    }
                }
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var shippingSlip = new ShippingSlip
            {
                Id = 12,
                CustomerId = customer.Id.ToString(),
                ProductType = ProductTypes.Video,
                ShippingDate = DateTime.Now
            };

            _context.ShippingSlips.Add(shippingSlip);
            _context.SaveChanges();
        }
    }
}
