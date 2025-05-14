using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IRestaurantCategoryRepository
    {
        public Task<List<RestaurantCategory>> GetAllAsync();

        public Task<RestaurantCategory?> GetByIdAsync(int restaurantId, int categoryId);

        public Task<List<Restaurant?>?> GetAllRestaurantByCategoryAsync(int categoryId, string? restaurantName = null, string? filter = null);

        public Task<List<Category?>?> GetAllCategoriesByRestaurantAsync(int restaurantId);

        public Task CreateAsync(RestaurantCategory restaurantCategory);

        public Task UpdateAsync(int restaurantId, int categoryId, bool isDeleted);
    }
}
