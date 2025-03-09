using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineSystem.Data;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.Repositories;

namespace OrderFoodOnlineSystem.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly OrderFoodDbContext _context;
        public CartRepository(OrderFoodDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            var carts = await _context.Carts
                .Include(c => c.Restaurant)
                .Include(c => c.SelectedAddress)
                .Include(c => c.OrderItems.Where(o => !o.IsDeleted))
                .ThenInclude(o => o.MenuItem)
                 .Where(c => !c.IsDeleted)
                 .ToListAsync();

            return carts;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            var cart = await _context.Carts
                .Include(c => c.Restaurant)
                .Include(c => c.SelectedAddress)
                .Include(c => c.OrderItems.Where(o => !o.IsDeleted))
                .ThenInclude(o => o.MenuItem)
                 .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cart != null)
            {
                if (cart.OrderItems == null || cart.OrderItems.Count() == 0)
                {
                    cart.TotalPrice = 0;
                    cart.RestaurantId = null;
                }
                else
                {
                    cart.TotalPrice = cart.OrderItems
                      .Where(oi => !oi.IsDeleted)
                      .Sum(oi => oi.TotalPrice);

                    cart.TotalPrice += cart.Restaurant?.DeliveryFees ?? 0;
                }

            }

            await _context.SaveChangesAsync();


            return cart;
        }

        public async Task<Cart?> GetByCustomerIdAsync(int customerId)
        {
            var cart = await _context.Carts
                .Include(c => c.Restaurant)
                .Include(c => c.SelectedAddress)
                .Include(c => c.OrderItems.Where(o => !o.IsDeleted))
                .ThenInclude(o => o.MenuItem)
                 .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (cart != null)
            {
                if (cart.OrderItems == null || cart.OrderItems.Count() == 0)
                {
                    cart.TotalPrice = 0;
                    cart.RestaurantId = null;
                }
                else
                {
                    cart.TotalPrice = cart.OrderItems
                      .Where(oi => !oi.IsDeleted)
                      .Sum(oi => oi.TotalPrice);

                    cart.TotalPrice += cart.Restaurant?.DeliveryFees ?? 0;
                }

            }

            await _context.SaveChangesAsync();


            return cart;
        }

        public async Task CreateAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await GetByIdAsync(id);
            if (cart != null)
            {
                cart.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart?> UpdateAsync(Cart cart)
        {
            var existingcart = await _context.Carts
                .Include(c => c.Restaurant)
                .Include(c => c.SelectedAddress)
                .Include(c => c.OrderItems.Where(o => !o.IsDeleted))
                .ThenInclude(o => o.MenuItem)
                 .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == cart.Id);

            if (existingcart != null)
            {
                existingcart.SelectedAddressId = cart.SelectedAddressId;
                existingcart.RestaurantId = cart.RestaurantId;
                existingcart.OrderItems = cart.OrderItems;

                if (existingcart.OrderItems == null || existingcart.OrderItems.Count() == 0)
                {
                    existingcart.TotalPrice = 0;
                }
                else
                {
                    existingcart.TotalPrice = cart.OrderItems
                        .Where(oi => !oi.IsDeleted)
                        .Sum(oi => oi.TotalPrice);
                    existingcart.TotalPrice += existingcart.Restaurant?.DeliveryFees ?? 0;
                }


            }
            await _context.SaveChangesAsync();
            return existingcart;
        }

        public async Task<Cart?> UpdateRestaurantIdAsync(int cartId, int? restaurantId)
        {
            var existingcart = await _context.Carts
                .Include(c => c.Restaurant)
                .Include(c => c.SelectedAddress)
                .Include(c => c.OrderItems.Where(o => !o.IsDeleted))
                .ThenInclude(o => o.MenuItem)
                 .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            if (existingcart != null)
            {
                existingcart.RestaurantId = restaurantId;
            }
            await _context.SaveChangesAsync();
            return existingcart;
        }



    }
}
