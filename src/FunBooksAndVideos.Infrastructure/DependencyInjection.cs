using FunBooksAndVideos.Domain.Interfaces;
using FunBooksAndVideos.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunBooksAndVideos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShippingSlipService, ShippingSlipService>();
            services.AddScoped<IMembershipActivationService, MembershipActivationService>();
            services.AddScoped<ICustomerServices, CustomerService>();
            services.AddScoped<IShippingSlip, ShippingService > ();
            
            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
