using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly OrderFoodDbContext dbContext;
      
        public RestaurantRepository(OrderFoodDbContext dbContext )
        {
            this.dbContext = dbContext;
           
        }

        public async Task<List<Restaurant>> GetAllAsync(string? restaurantName = null, string? filter = null)
        {
            var query = dbContext.Restaurants
                .Include(s => s.RestaurantManager)
                .Where(r => r.IsDeleted == false);

            if (restaurantName != null)
            {
                query = query.Where(r => r.Name.ToLower().Contains(restaurantName.ToLower()));
            }

            if (filter == "Name")
            {
                query = query.OrderBy(r => r.Name);
            }
            else
            {
                query = query.OrderByDescending(r => r.AverageRating).ThenBy(r => r.Name);
            }

            return await query.ToListAsync();
        }


        public async Task<Restaurant?> GetByIdAsync(int id)
        {
            return await dbContext.Restaurants
                .Include(r => r.RestaurantManager)
                .Include(r=>r.MenuItems)
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Restaurant?> GetByManagerIdAsync(int maagerId)
        {
            return await dbContext.Restaurants
                .Include(r => r.RestaurantManager)
                .Include(r => r.MenuItems)
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.RestaurantManagerId == maagerId);
        }

        public async Task<Restaurant?> CreateAsync(Restaurant restaurant)
        {
            if (restaurant == null)
                return null;

            await dbContext.Restaurants.AddAsync(restaurant);
            await dbContext.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant?> UpdateAsync(int id, Restaurant restaurant)
        {
            var existingRestaurant = await dbContext.Restaurants
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            if (existingRestaurant == null)
                return null;

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Description = restaurant.Description;
            existingRestaurant.ImageUrl = restaurant.ImageUrl;
            existingRestaurant.DateOpen = restaurant.DateOpen;
            existingRestaurant.DateColse = restaurant.DateColse;
            existingRestaurant.RestaurantManagerId = restaurant.RestaurantManagerId;

            await dbContext.SaveChangesAsync();
            return existingRestaurant;
        }

        public async Task<Restaurant?> DeleteAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Where(r => r.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant == null)
            {
                return null;
            }

            restaurant.IsDeleted = true;

            //dbContext.Entry(restaurant).Property(x => x.IsDeleted).IsModified = true;

            await dbContext.SaveChangesAsync();
            return restaurant;
        }

        public async Task CalculateAverageRating(int? id) //restaurantId
        {
            var restaurant = await dbContext.Restaurants
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant != null)
            {

                if (restaurant.Reviews != null)
                {
                    var activeReviews = restaurant.Reviews.Where(r => r.IsDeleted == false).ToList();
                    if (activeReviews.Any())
                    {
                        restaurant.AverageRating = Math.Round(activeReviews.Average(r => r.Rating), 1);
                    }
                    else
                    {
                        restaurant.AverageRating = 0;
                    }
                }
                else
                {
                    restaurant.AverageRating = 0;
                }
                await dbContext.SaveChangesAsync();
            }
        }
    
    }
}
