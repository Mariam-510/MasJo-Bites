using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;

namespace OrderFoodOnlineSystem.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderFoodDbContext _context;
        public OrderRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                 .Include(o => o.Customer)
                 .Include(o => o.Address)
                 .Include(o => o.Restaurant)
                 .Include(o => o.OrderItems)
                 .Where(o => !o.IsDeleted)
                 .ToListAsync();
        }

        public async Task<List<Order>> GetAllByRestaurantAsync(int restaurantManagerId) //restaurant id
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Restaurant)
                .Include(o => o.Address)
                .Where(o => o.IsDeleted == false && o.Restaurant.RestaurantManagerId == restaurantManagerId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllByCustomerAsync(int customerId) //customer id
        {
            return await _context.Orders
               .Include(o => o.Customer)
               .Include(o => o.Address)
               .Include(o => o.Restaurant)
              .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.IsDeleted == false && o.CustomerId == customerId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
               .Include(o => o.Customer)
               .Include(o => o.Address)
               .Include(o => o.Restaurant)
              .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
               .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
        }

        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.Status = order.Status;
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

    }


        
}
