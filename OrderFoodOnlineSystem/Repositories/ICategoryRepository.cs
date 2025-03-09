using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<Category?> CreateAsync(Category category);
        public Task<Category?> UpdateAsync(int id, Category category);
        public Task<Category?> DeleteAsync(int id);
        public Task<List<Category>> GetAllMissingAsync(int restaurantId);

    }
}
