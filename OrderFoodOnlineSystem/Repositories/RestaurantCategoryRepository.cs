using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrderFoodOnlineSystem.Repositories
{
    public class RestaurantCategoryRepository : IRestaurantCategoryRepository
    {
        public OrderFoodDbContext _context { get; }

        public RestaurantCategoryRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<RestaurantCategory>> GetAllAsync()
        {
            return await _context.RestaurantCategories
                .Include(rc => rc.Category)
                .Include(rc => rc.Restaurant)
                .Where(rc => rc.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<RestaurantCategory?> GetByIdAsync(int restaurantId, int categoryId)
        {
            return await _context.RestaurantCategories
                .Include(rc => rc.Category)
                .Include(rc => rc.Restaurant)
                .Where(rc => rc.RestaurantId == restaurantId && rc.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Restaurant?>?> GetAllRestaurantByCategoryAsync(int categoryId, string? restaurantName = null, string? filter = null)
        {
            if (!await _context.Categories.AnyAsync(c => c.Id == categoryId))
                return null;

            var query = _context.RestaurantCategories
                .Include(rc => rc.Restaurant)
                .Where(rc => rc.CategoryId == categoryId && rc.IsDeleted == false)
                .Select(rc => rc.Restaurant);
            
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
                query = query.OrderByDescending(r => r.AverageRating).ThenBy(r=>r.Name);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Category?>?> GetAllCategoriesByRestaurantAsync(int restaurantId)
        {
            if (!await _context.Restaurants.AnyAsync(r => r.Id == restaurantId))
                return null;

            return await _context.RestaurantCategories
                .Include(rc => rc.Category)
                .Where(rc => rc.RestaurantId == restaurantId && rc.IsDeleted == false && !rc.Category.IsDeleted)
                .OrderBy(rc=>rc.Category.Name)
                .Select(rc => rc.Category)
                .ToListAsync();
        }

        public async Task CreateAsync(RestaurantCategory restaurantCategory)
        {
            await _context.RestaurantCategories.AddAsync(restaurantCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int restaurantId, int categoryId, bool isDeleted)
        {
            var restaurantCategory = await _context.RestaurantCategories
            .FirstOrDefaultAsync(f => f.RestaurantId == restaurantId && f.CategoryId == categoryId);

            if (restaurantCategory != null)
            {
                restaurantCategory.IsDeleted = isDeleted;

                await _context.SaveChangesAsync();
            }

        }
    }
}
