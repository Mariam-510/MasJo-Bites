using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;

namespace OrderFoodOnlineSystem.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        public OrderFoodDbContext _context { get; }

        public MenuItemRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems
                .Include(mi => mi.Restaurant)
                .Include(mi => mi.Category)
                .Where(mi => mi.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<MenuItem>> GetAllByRestaurantAsync(int restaurantId)
        {
            return await _context.MenuItems
                .Include(mi => mi.Restaurant)
                .Include(mi => mi.Category)
                .Where(mi => mi.IsDeleted == false && mi.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await _context.MenuItems
                .Include(mi => mi.Restaurant)
                .Include(mi => mi.Category)
                .Where(mi => mi.IsDeleted == false)
                .FirstOrDefaultAsync(mi => mi.Id == id);
        }

        public async Task<MenuItem?> CreateAsync(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                await _context.MenuItems.AddAsync(menuItem);
                await _context.SaveChangesAsync();
                return menuItem;
            }
            else
                return null;
        }

        public async Task<MenuItem?> UpdateAsync(int id, MenuItem menuItem)
        {
            var updatedMenuItem = await GetByIdAsync(id);

            if (updatedMenuItem != null)
            {
                updatedMenuItem.Name = menuItem.Name;
                updatedMenuItem.Description = menuItem.Description;
                updatedMenuItem.Price = menuItem.Price;
                updatedMenuItem.ImageUrl = menuItem.ImageUrl;
                updatedMenuItem.IsAvailable = menuItem.IsAvailable;
                updatedMenuItem.CategoryId = menuItem.CategoryId;

                await _context.SaveChangesAsync();
                return updatedMenuItem;
            }
            else
                return null;
        }

        public async Task<MenuItem?> DeleteAsync(int id)
        {
            var deletedItem = await GetByIdAsync(id);

            if (deletedItem != null)
            {
                deletedItem.IsAvailable = false;
                deletedItem.IsDeleted = true;
                await _context.SaveChangesAsync();
                return deletedItem;
            }
            else
                return null;
        }
    }
}
