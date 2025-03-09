using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Mapping;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;
using System.Collections;
using static NuGet.Packaging.PackagingConstants;

namespace OrderFoodOnlineSystem.Services
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderFoodDbContext _context;
        public OrderItemRepository(OrderFoodDbContext dbontext)
        {
            _context = dbontext;
        }
        
        public async Task<List<OrderItem>> GetAllAsync()
        {
            var orderItems = await _context.OrderItems
                .Where(o => o.IsDeleted == false)
                .Include(o => o.MenuItem).ToListAsync();

            await _context.SaveChangesAsync();
            return orderItems;

        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            var orderItem = await _context.OrderItems
                .Include(I => I.MenuItem)
                .FirstOrDefaultAsync(orderItem => orderItem.Id == id);

            return orderItem;
        }
        
        public async Task<OrderItem> CreateAsync(OrderItem orderItem)
        {
            if (orderItem.MenuItemId != null)
            {
                var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == orderItem.MenuItemId);
                if (menuItem != null)
                {
                    orderItem.TotalPrice = orderItem.Quantity * menuItem.Price;
                }
            }
            await _context.OrderItems.AddAsync(orderItem);

            await _context.SaveChangesAsync();

            return orderItem;
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await _context.OrderItems
               .Include(o => o.MenuItem)
               .FirstOrDefaultAsync(o => o.Id == id);

            if (orderItem != null)
            {
                orderItem.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderItem?> UpdateOrderItemQuantityAsync(OrderItem orderItem)
        {
            var existingOrderItem = await _context.OrderItems
               .Include(o => o.MenuItem)
               .Where(o => !o.IsDeleted)
               .FirstOrDefaultAsync(o => o.Id == orderItem.Id);

            if (existingOrderItem == null)
            {
                return null;
            }
            existingOrderItem.Quantity = orderItem.Quantity;

            if (orderItem.Quantity == 0)
            {
                existingOrderItem.IsDeleted = true;
            }
            else
            {
                if (existingOrderItem.MenuItemId != null)
                {
                    existingOrderItem.TotalPrice = orderItem.Quantity * existingOrderItem.MenuItem.Price;
                }
            }

            await _context.SaveChangesAsync();

            return existingOrderItem;
        }


        public async Task<OrderItem?> UpdateAsync(OrderItem orderItem)
        {
            var existingOrderItem = await _context.OrderItems
               .Include(o => o.MenuItem)
               .Where(o => !o.IsDeleted)
               .FirstOrDefaultAsync(o => o.Id == orderItem.Id);

            if (existingOrderItem == null)
            {
                return null;
            }
            existingOrderItem.CartId = orderItem.CartId;
            existingOrderItem.OrderId = orderItem.OrderId;


            await _context.SaveChangesAsync();

            return existingOrderItem;
        }

        public async Task<OrderItem?> Exists(int cartId, int menuItemId)
        {
            var orderItem = await _context.OrderItems
                .Where(o=>!o.IsDeleted)
                .FirstOrDefaultAsync(o => o.CartId == cartId && o.MenuItemId == menuItemId);
            
            return orderItem;
        }


    }
}
