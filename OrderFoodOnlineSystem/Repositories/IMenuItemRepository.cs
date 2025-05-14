using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItem>> GetAllAsync();
        Task<List<MenuItem>> GetAllByRestaurantAsync(int restaurantId);
        Task<MenuItem?> GetByIdAsync(int id);
        Task<MenuItem?> CreateAsync(MenuItem menuItem);
        Task<MenuItem?> UpdateAsync(int id, MenuItem menuItem);
        Task<MenuItem?> DeleteAsync(int id);
    }
}
