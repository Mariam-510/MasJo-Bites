using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public OrderFoodDbContext _context { get; }

        public CategoryRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Where(c => c.IsDeleted == false)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category != null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }
            else
                return null;
        }

        public async Task<Category?> UpdateAsync(int id, Category category)
        {
            var updatedCategory = await GetByIdAsync(id);

            if (updatedCategory != null)
            {
                updatedCategory.Name = category.Name;
                updatedCategory.ImageUrl = category.ImageUrl;

                await _context.SaveChangesAsync();
                return updatedCategory;
            }
            else
                return null;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var deletedCategory = await GetByIdAsync(id);

            if (deletedCategory != null)
            {
                deletedCategory.IsDeleted = true;
                await _context.SaveChangesAsync();
                return deletedCategory;
            }
            else
                return null;
        }

        public async Task<List<Category>> GetAllMissingAsync(int restaurantId)
        {
            return await _context.Categories
                .Where(c => c.IsDeleted == false)
                .Where(c => c.RestaurantCategories.All(rc => rc.RestaurantId != restaurantId ||
                (rc.RestaurantId == restaurantId && rc.IsDeleted)))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

    }
}
