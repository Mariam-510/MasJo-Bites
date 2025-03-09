using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllAsync(string? restaurantName = null, string? filter = null);
        Task<Restaurant?> GetByIdAsync(int id);
        Task<Restaurant?> GetByManagerIdAsync(int mangerIid);
        Task<Restaurant?> CreateAsync(Restaurant restaurant);
        Task<Restaurant?> UpdateAsync(int id, Restaurant restaurant);
        Task<Restaurant?> DeleteAsync(int id);
        Task CalculateAverageRating(int? restaurantId);

    }
}
