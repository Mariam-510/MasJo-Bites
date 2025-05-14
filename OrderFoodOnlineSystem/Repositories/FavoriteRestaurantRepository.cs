using Microsoft.CodeAnalysis.Rename;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class FavoriteRestaurantRepository : IFavouriteRestaurantRepository
    {
        private readonly OrderFoodDbContext dbContext;

        public FavoriteRestaurantRepository(OrderFoodDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public async Task<List<FavouriteRestaurant>> GetAllAsync()
        {
            return await dbContext.FavouriteRestaurants
                .Include(f => f.Customer)
                .Include(f => f.Restaurant)
                .Where(f => f.IsDeleted == false)
                .OrderByDescending(f => f.DateTime)
                .ToListAsync();
        }

        public async Task<List<FavouriteRestaurant>?> GetAllByCustomerAsync(int customerId)
        {
            if (!await dbContext.Customers.AnyAsync(c => c.Id == customerId))
                return null;

            return await dbContext.FavouriteRestaurants
                .Include(f => f.Customer)
                .Include(f => f.Restaurant)
                .Where(f => f.IsDeleted == false && f.CustomerId == customerId)
                .OrderByDescending(f => f.DateTime)
                .ToListAsync();
        }

        public async Task<List<Restaurant?>?> GetAllRestaurantByCustomerAsync(int customerId)
        {
            if (!await dbContext.Customers.AnyAsync(c => c.Id == customerId))
                return null;

            return await dbContext.FavouriteRestaurants
                .Include(f => f.Customer)
                .Include(f => f.Restaurant)
                .Where(f => f.IsDeleted == false && f.CustomerId == customerId)
                .OrderByDescending(f=>f.DateTime)
                .Select(f => f.Restaurant)
                .ToListAsync();
        }

        public async Task<FavouriteRestaurant?> GetByIdAsync(int restaurantId, int customerId)
        {
            return await dbContext.FavouriteRestaurants
                .Include(f => f.Customer)
                .Include(f => f.Restaurant)
                .Where(f => f.RestaurantId == restaurantId && f.CustomerId == customerId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(FavouriteRestaurant favouriteRestaurant)
        {
            await dbContext.FavouriteRestaurants.AddAsync(favouriteRestaurant);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int restaurantId, int customerId, bool isDeleted)
        {
            var favourite = await dbContext.FavouriteRestaurants
                .FirstOrDefaultAsync(f => f.RestaurantId == restaurantId && f.CustomerId == customerId);

            if (favourite != null)
            {
                if (!isDeleted)
                    favourite.DateTime = DateTime.Now;

                favourite.IsDeleted = isDeleted;
                
                await dbContext.SaveChangesAsync();  
            }
        }

    }
}
