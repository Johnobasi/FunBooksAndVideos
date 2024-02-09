using AutoMapper;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Infrastructure.Services
{
    public class CustomerService : ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomerService> _logger;
        private readonly IMapper _mapper;
        public CustomerService(ApplicationDbContext context, ILogger<CustomerService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Customer> GetCustomerById(string customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer == null)
            {
                _logger.LogError($"Customer with id {customerId} not found");
                throw new Exception($"Customer with id {customerId} not found");
            }
            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var customerToUpdate = await GetCustomerById(customer.Id.ToString());
            if (customerToUpdate == null)
            {
                _logger.LogError($"Customer with id {customer.Id} not found");
                throw new Exception($"Customer with id {customer.Id} not found");
            }
            _mapper.Map(customer, customerToUpdate);
            customerToUpdate.Name = customer.Name;
            customerToUpdate.IsMember = customer.IsMember;
            _context.Customers.Update(customerToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
