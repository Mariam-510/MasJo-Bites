using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByAccountIdAsync(string accountId);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, Customer customer);
        Task<Customer?> DeleteAsync(int id);
    
    }
}
