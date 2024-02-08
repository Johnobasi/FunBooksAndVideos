using FunBooksAndVideos.Domain.Dtos;
using FunBooksAndVideos.Domain.Entities;

namespace FunBooksAndVideos.Domain.Interfaces
{
    public interface ICustomerServices
    {
        Task<Customer> GetCustomerById(string customerId);
        Task UpdateCustomer(Customer customer);
    }
}
