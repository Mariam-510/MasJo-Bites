using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class RestaurantManagerRepository : IRestaurantManagerRepository
    {
        private readonly OrderFoodDbContext dbContext;
        public RestaurantManagerRepository(OrderFoodDbContext dbontext)
        {
            this.dbContext = dbontext;
        }

        public async Task<List<RestaurantManager>> GetAllAsync()
        {
            return await dbContext.RestaurantManagers
                .Include(m=>m.Account)
                //.Include(m=>m.Restaurant)
                .Where(m=>!m.IsDeleted)
                //.OrderBy(m=>m.Name)
                .ToListAsync();
        }

        public async Task<RestaurantManager?> GetByIdAsync(int id)
        {
            return await dbContext.RestaurantManagers
                .Include(m => m.Account)
                 //.Include(m => m.Restaurant)
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<RestaurantManager?> GetByAccountIdAsync(string accountId)
        {
            return await dbContext.RestaurantManagers
                .Include(m => m.Account)
                //.Include(m => m.Restaurant)
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync(m => m.Account.Id == accountId);
        }

        public async Task<RestaurantManager> CreateAsync(RestaurantManager restaurantManager)
        {
            await dbContext.RestaurantManagers.AddAsync(restaurantManager);
            await dbContext.SaveChangesAsync();
            return restaurantManager;
        }

        public async Task<RestaurantManager?> UpdateAsync(int id, RestaurantManager restaurantManager)
        {
            var existingRestaurantManager = await dbContext.RestaurantManagers
                .Include(m => m.Account)
                //.Include(m => m.Restaurant)
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (existingRestaurantManager == null)
            {
                return null;
            }
            existingRestaurantManager.Name = restaurantManager.Name;
            //existingRestaurantManager.RestaurantId = restaurantManager.RestaurantId;

            await dbContext.SaveChangesAsync();
            return existingRestaurantManager;
        }

        public async Task<RestaurantManager?> DeleteAsync(int id)
        {
            var existingRestaurantManager = await dbContext.RestaurantManagers
                .Include(m => m.Account)
                //.Include(m => m.Restaurant)
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (existingRestaurantManager == null)
            {
                return null;
            }
            existingRestaurantManager.IsDeleted = true;
            existingRestaurantManager.AccountId = null;

            await dbContext.SaveChangesAsync();
            return existingRestaurantManager;
        }
    
    }
}
