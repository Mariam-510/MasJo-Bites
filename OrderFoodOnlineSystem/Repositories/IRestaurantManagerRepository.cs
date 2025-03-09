using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IRestaurantManagerRepository
    {
        Task<List<RestaurantManager>> GetAllAsync();
        Task<RestaurantManager?> GetByIdAsync(int id);
        Task<RestaurantManager?> GetByAccountIdAsync(string accountId);
        Task<RestaurantManager> CreateAsync(RestaurantManager restaurantManager);
        Task<RestaurantManager?> UpdateAsync(int id, RestaurantManager restaurantManager);
        Task<RestaurantManager?> DeleteAsync(int id);
    
    }
}
