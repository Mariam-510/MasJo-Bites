using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetAllAsync();
        public Task<List<Review>> GetAllByRestaurantAsync(int restaurantId);
        public Task<int> GetCountOfRestaurantReviewsAsync(int restaurantId);
        public Task<List<Review>> GetAllByCustomerAsync(int customerId);
        public Task<Review?> GetByIdAsync(int id);
        public Task<Review?> CreateAsync(Review Review);
        public Task<Review?> UpdateAsync(int id, Review Review);
        public Task<Review?> DeleteAsync(int id);
    }
}
