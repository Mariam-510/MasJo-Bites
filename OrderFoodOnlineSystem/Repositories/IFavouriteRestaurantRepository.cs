using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IFavouriteRestaurantRepository
    {
        Task<List<FavouriteRestaurant>> GetAllAsync();
        Task<List<FavouriteRestaurant>?> GetAllByCustomerAsync(int customerId);
        Task<List<Restaurant?>?> GetAllRestaurantByCustomerAsync(int customerId);
        Task<FavouriteRestaurant?> GetByIdAsync(int restaurantId, int customerId);
        Task CreateAsync(FavouriteRestaurant favouriteRestaurant);
        Task UpdateAsync(int restaurantId, int customerId, bool isDeleted);
    }
}
