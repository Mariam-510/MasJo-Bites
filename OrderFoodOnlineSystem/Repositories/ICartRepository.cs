using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllAsync();
        Task<Cart?> GetByIdAsync(int id);
        Task<Cart?> GetByCustomerIdAsync(int customerId);
        Task CreateAsync(Cart cart);
        Task<Cart?> UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
        Task<Cart?> UpdateRestaurantIdAsync(int cartId, int? restaurantId);

    }
}
