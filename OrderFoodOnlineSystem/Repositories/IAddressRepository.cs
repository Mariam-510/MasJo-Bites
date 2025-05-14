using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IAddressRepository
    {
        public Task<List<Address>> GetAllAsync();
        Task<List<Address>> GetAllByCustomerAsync(int customerId);
        public Task<Address?> GetByIdAsync(int id);
        public Task<Address?> CreateAsync(Address Address);
        public Task<Address?> UpdateAsync(int id, Address Address);
        public Task<Address?> DeleteAsync(int id);
    
    }
}
