using FunBooksAndVideos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ItemLine> ItemLines { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
