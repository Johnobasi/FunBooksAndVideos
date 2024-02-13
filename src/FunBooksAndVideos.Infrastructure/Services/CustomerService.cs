using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Exceptions;
using FunBooksAndVideos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ApplicationDbContext context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Customer?> GetCustomerById(string customerId)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(customerId);

                if (customer == null)
                {
                    _logger.LogError($"Customer with id {customerId} not found");
                    throw new NotFoundException($"Customer with id {customerId} not found");
                }
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCustomerById: {ex.Message}\n{ex.StackTrace}");
            }

            return null;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                var customerToUpdate = await GetCustomerById(customer.Id.ToString());
                if (customerToUpdate == null)
                {
                    _logger.LogError($"Customer with id {customer.Id} not found");
                    throw new Exception($"Customer with id {customer.Id} not found");
                }
                _context.Customers.Update(customerToUpdate);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error in UpdateCustomer: {ex.Message}\n{ex.StackTrace}");
            }

        }
    }
}
